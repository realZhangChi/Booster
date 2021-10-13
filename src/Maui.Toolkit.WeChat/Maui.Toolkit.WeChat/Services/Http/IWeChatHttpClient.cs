using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Http;

public interface IWeChatHttpClient
{
    Task<Token?> GetTokenAsync(string code);

    Task<Token?> RefreshTokenAsync(string refreshToken);

    Task<UserInfo?> GetUserInfoAsync(Token token);
}
