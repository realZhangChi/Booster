using Maui.Toolkit.WeChat.Services.Http;
using System;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class DefaultAuthorizationService : IAuthorizationService
{
    private readonly IAuthorizationHandler _handler;
    private readonly ITokenStore _tokenStore;
    private readonly IUserInfoStore _userInfoStore;
    private readonly IWeChatHttpClient _weChatHttpClient;

    public DefaultAuthorizationService(
        IAuthorizationHandler handler,
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
        var token = await _weChatHttpClient.GetTokenAsync(appId, appSecret, code);
        token.IssuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        await _tokenStore.SetAsync(token);

        var userInfo = await _weChatHttpClient.GetUserInfoAsync(token.AccessToken, token.OpenId);
        await _userInfoStore.SetAsync(userInfo);
    }
}
