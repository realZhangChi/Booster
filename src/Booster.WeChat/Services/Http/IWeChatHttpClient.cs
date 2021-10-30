using System.Threading.Tasks;

using Booster.WeChat.Models.Identity;

namespace Booster.WeChat.Services.Http;

public interface IWeChatHttpClient
{
    Task<Token> GetTokenAsync(string appId, string appSecret, string code);

    Task<Token> RefreshTokenAsync(string appId, string refreshToken);

    Task<UserInfo> GetUserInfoAsync(string accessToken, string openId);
}
