using System;
using System.Net.Http;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Utils;

using Microsoft.Extensions.Options;

namespace Maui.Toolkit.WeChat.Services.Http;

public class DefaultWeChatHttpClient : IWeChatHttpClient
{
    private readonly HttpClient _httpClient;

    public DefaultWeChatHttpClient(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.weixin.qq.com");
    }

    public async Task<Token> GetTokenAsync(string appId, string appSecret, string code)
    {
        var tokenUrl = $"/sns/oauth2/access_token?appid={appId}&secret={appSecret}&code={code}&grant_type=authorization_code";

        var response = await _httpClient.GetAsync(tokenUrl);

        return await response.EnsureSuccessAndDeserializeAsync<Token>();
    }

    public async Task<UserInfo> GetUserInfoAsync(Token token)
    {

        var userInfoUrl = $"/sns/userinfo?access_token={token.AccessToken}&openid={token.OpenId}";

        var response = await _httpClient.GetAsync(userInfoUrl);

        return await response.EnsureSuccessAndDeserializeAsync<UserInfo>();
    }

    public async Task<Token> RefreshTokenAsync(string appId, string refreshToken)
    {
        var refreshTokenUrl = $"/sns/oauth2/refresh_token?appid={appId}&grant_type=refresh_token&refresh_token={refreshToken}";

        var response = await _httpClient.GetAsync(refreshTokenUrl);

        return await response.EnsureSuccessAndDeserializeAsync<Token>();
    }
}
