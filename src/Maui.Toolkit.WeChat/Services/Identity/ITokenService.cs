using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface ITokenService
{
    Task<Token?> GetTokenFromWeChatAsync(string appId, string appSecret, string code);

    Task<Token?> RefreshTokenAsync(string appId, string refreshToken);
}
