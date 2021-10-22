using System;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Services.Http;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class DefaultUserInfoService : IUserInfoService
{
    private readonly ITokenStore _tokenStore;
    private readonly ITokenService _tokenService;
    private readonly IWeChatHttpClient _weChatClient;

    public DefaultUserInfoService(
        ITokenStore tokenStore,
        ITokenService tokenService,
        IWeChatHttpClient weChatClient)
    {
        _tokenStore = tokenStore;
        _tokenService = tokenService;
        _weChatClient = weChatClient;
    }

    public async Task<UserInfo?> GetUserInfoFromWeChatAsync(string appId)
    {
        var token = await _tokenStore.GetOrNullAsync();
        if (token == null)
        {
            return null;
        }

        // 1200 seconds = 20 minutes
        if (token.IssuedAt + token.ExpiresIn - 1200 > DateTimeOffset.UtcNow.ToUnixTimeSeconds())
        {
            // 2419200 seconds = 28 days
            if (token.IssuedAt + 2419200 > DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            {
                // TODO: refresh_token expired exception
                throw new NotImplementedException();
            }

            await _tokenService.RefreshTokenAsync(appId, token.RefreshToken);
        }


        var userInfo = await _weChatClient.GetUserInfoAsync(token.AccessToken, token.OpenId);

        return userInfo;
    }
}
