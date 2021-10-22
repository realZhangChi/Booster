using System;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Services.Http;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class DefaultTokenService : ITokenService
{
    private readonly IWeChatHttpClient _weChatClient;

    public DefaultTokenService(IWeChatHttpClient weChatClient)
    {
        _weChatClient = weChatClient;
    }

    public virtual async Task<Token?> GetTokenFromWeChatAsync(string appId, string appSecret, string code)
    {
        if (string.IsNullOrWhiteSpace(appId))
            throw new ArgumentNullException(nameof(appId));
        if (string.IsNullOrWhiteSpace(appSecret))
            throw new ArgumentNullException(nameof(appSecret));
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentNullException(nameof(code));

        var token = await _weChatClient.GetTokenAsync(appId, appSecret, code);
        if (token is not null)
        {
            token.IssuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        return token;
    }

    public async Task<Token?> RefreshTokenAsync(string appId, string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(appId))
            throw new ArgumentNullException(nameof(appId));
        if (string.IsNullOrWhiteSpace(refreshToken))
            throw new ArgumentNullException(nameof(refreshToken));

        var refreshedToken = await _weChatClient.RefreshTokenAsync(appId, refreshToken);
        if (refreshedToken is not null)
        {
            refreshedToken.IssuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        return refreshedToken;
    }
}
