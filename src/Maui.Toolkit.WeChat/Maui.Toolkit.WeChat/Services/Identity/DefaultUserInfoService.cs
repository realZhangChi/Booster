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

    public async Task<UserInfo?> GetUserInfoFromWeChatAsync(string? openId = null)
    {
        var token = await _tokenStore.GetOrNullAsync();
        if (token == null)
        {
            return null;
        }

        // 1200 seconds = 20 minutes
        if (token.IssuedAt + token.ExpiresIn - 1200 > DateTimeOffset.UtcNow.ToUnixTimeSeconds())
        {
            await _tokenService.RefreshTokenAsync();
        }

        if (!string.IsNullOrWhiteSpace(openId))
        {
            token.OpenId = openId;
        }
        var userInfo = await _weChatClient.GetUserInfoAsync(token);

        return userInfo;
    }
}
