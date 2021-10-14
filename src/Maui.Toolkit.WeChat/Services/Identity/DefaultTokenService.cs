using System;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Services.Http;

namespace Maui.Toolkit.WeChat.Services.Identity;

internal class DefaultTokenService : ITokenService
{
    private readonly ITokenStore _tokenStore;
    private readonly IWeChatHttpClient _weChatClinet;

    public DefaultTokenService(
        ITokenStore tokenStore,
        IWeChatHttpClient weChatClient)
    {
        _tokenStore = tokenStore;
        _weChatClinet = weChatClient;
    }

    public virtual async Task<Token?> GetTokenFromWeChatAsync(string appId, string appSecret, string code)
    {
        var token = await _weChatClinet.GetTokenAsync(appId, appSecret, code);
        if (token is not null)
        {
            token.IssuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        return token;
    }

    public async Task<Token?> RefreshTokenAsync(string appId)
    {
        var token = await _tokenStore.GetOrNullAsync();
        if (token is null || string.IsNullOrWhiteSpace(token.RefreshToken))
        {
            // TODO: NULL token exception
            throw new NotImplementedException();
        }
        // 2419200 seconds = 28 days
        if (token.IssuedAt + 2419200 > DateTimeOffset.UtcNow.ToUnixTimeSeconds())
        {
            // TODO: refresh_token expired exception
            throw new NotImplementedException();
        }

        var refreshedToken = await _weChatClinet.RefreshTokenAsync(appId, token.RefreshToken);
        if (refreshedToken is not null)
        {
            refreshedToken.IssuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        return refreshedToken;
    }
}
