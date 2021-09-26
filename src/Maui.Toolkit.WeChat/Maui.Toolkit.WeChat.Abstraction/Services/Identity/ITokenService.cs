using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface ITokenService
{
    Task<Token?> GetTokenFromWeChatAsync(string code);

    Task<Token?> RefreshTokenAsync();
}
