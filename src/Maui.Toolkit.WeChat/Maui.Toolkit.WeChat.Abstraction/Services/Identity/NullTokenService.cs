namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullTokenService : ITokenService
{
    public Task<Token?> GetTokenFromWeChatAsync(string appId, string appSecret, string code)
    {
        return Task.FromResult((Token?)null);
    }

    public Task<Token?> RefreshTokenAsync(string appId)
    {
        return Task.FromResult((Token?)null);
    }
}
