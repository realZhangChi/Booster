using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Http;

public interface IWeChatHttpClient
{
    Task<Token> GetTokenAsync(string appId, string appSecret, string code);

    Task<Token> RefreshTokenAsync(string appId, string refreshToken);

    Task<UserInfo> GetUserInfoAsync(string accessToken, string openId);
}
