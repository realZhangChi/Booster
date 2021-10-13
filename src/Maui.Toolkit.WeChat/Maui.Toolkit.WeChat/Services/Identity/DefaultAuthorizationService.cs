using System;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class DefaultAuthorizationService : IAuthorizationService
{
    private readonly IAuthorizationHandler _handler;
    private readonly ITokenService _tokenService;
    private readonly ITokenStore _tokenStore;
    private readonly IUserInfoService _userInfoService;
    private readonly IUserInfoStore _userInfoStore;

    public DefaultAuthorizationService(
        IAuthorizationHandler handler,
        ITokenService tokenService,
        ITokenStore tokenStore,
        IUserInfoService userInfoService,
        IUserInfoStore userInfoStore)
    {
        _handler = handler;
        _tokenService = tokenService;
        _tokenStore = tokenStore;
        _userInfoService = userInfoService;
        _userInfoStore = userInfoStore;
    }
    public virtual Task<bool> AuthorizeAsync()
    {
        return _handler.AuthorizeAsync();
    }

    public virtual async Task AuthorizeCallbackAsync(string code)
    {
        var token = await _tokenService.GetTokenFromWeChatAsync(code);
        if (token == null)
        {
            throw new NotImplementedException();
        }
        await _tokenStore.SetAsync(token);

        var userInfo = await _userInfoService.GetUserInfoFromWeChatAsync();
        if (userInfo == null)
        {
            throw new NotImplementedException();
        }
        await _userInfoStore.SetAsync(userInfo);
    }
}
