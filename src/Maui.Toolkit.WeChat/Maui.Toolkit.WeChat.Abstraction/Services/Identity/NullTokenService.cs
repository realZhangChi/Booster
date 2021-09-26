using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullTokenService : ITokenService
{
    public Task<Token?> GetTokenFromWeChatAsync(string code)
    {
        return Task.FromResult((Token?)null);
    }

    public Task<Token?> RefreshTokenAsync()
    {
        return Task.FromResult((Token?)null);
    }
}
