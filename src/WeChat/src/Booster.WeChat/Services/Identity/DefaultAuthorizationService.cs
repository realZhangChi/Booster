﻿using Booster.WeChat.Services.Http;

using Microsoft.Maui.Controls;

using System;
using System.Threading.Tasks;
using Booster.WeChat.Models.Identity;

namespace Booster.WeChat.Services.Identity;

public class DefaultAuthorizationService : IAuthorizationService
{
    private readonly IPlatformAuthorizer _handler;
    private readonly ITokenStore _tokenStore;
    private readonly IUserInfoStore _userInfoStore;
    private readonly IWeChatHttpClient _weChatHttpClient;

    public DefaultAuthorizationService(
        IPlatformAuthorizer handler,
        ITokenStore tokenStore,
        IUserInfoStore userInfoStore,
        IWeChatHttpClient weChatHttpClient)
    {
        _handler = handler;
        _tokenStore = tokenStore;
        _userInfoStore = userInfoStore;
        _weChatHttpClient = weChatHttpClient;
    }
    public virtual Task<bool> AuthorizeAsync()
    {
        return _handler.AuthorizeAsync();
    }

    public virtual async Task AuthorizeCallbackAsync(string appId, string appSecret, string code)
    {
        if (string.IsNullOrWhiteSpace(appId))
            throw new ArgumentNullException(nameof(appId));
        if (string.IsNullOrWhiteSpace(appSecret))
            throw new ArgumentNullException(nameof(appSecret));
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentNullException(nameof(code));

        Token? token;
        try
        {
            token = await _weChatHttpClient.GetTokenAsync(appId, appSecret, code);
            if (token is null)
            {
                MessagingCenter.Send(
                    (IAuthorizationService)this,
                    AuthorizationMessages.Failed,
                    AuthorizationMessageArgs.FailedInstance("Token is NULL!"));
                return;
            }
            await _tokenStore.SetAsync(token);
        }
        catch (Exception e)
        {
            MessagingCenter.Send(
                (IAuthorizationService)this,
                AuthorizationMessages.Failed,
                AuthorizationMessageArgs.FailedInstance(e.Message, e));
            return;
        }

        var userInfo = await _weChatHttpClient.GetUserInfoAsync(token.AccessToken, token.OpenId);
        if (userInfo is not null)
        {
            await _userInfoStore.SetAsync(userInfo);
        }

        MessagingCenter.Send((IAuthorizationService)this, AuthorizationMessages.Success, AuthorizationMessageArgs.SuccessInstance());
    }
}
