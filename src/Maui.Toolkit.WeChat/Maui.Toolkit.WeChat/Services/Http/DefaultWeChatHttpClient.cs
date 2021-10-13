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
    private readonly WeChatOption _option;

    public DefaultWeChatHttpClient(
        HttpClient httpClient,
        IOptions<WeChatOption> option)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.weixin.qq.com");

        _option = option.Value;
    }

    public async Task<Token?> GetTokenAsync(string code)
    {
        var tokenUrl = $"/sns/oauth2/access_token?appid={_option.AppId}&secret={_option.AppSecret}&code={code}&grant_type=authorization_code";

        var response = await _httpClient.GetAsync(tokenUrl);

        return await response.EnsureSuccessAndDeserializeAsync<Token>();
    }

    public async Task<UserInfo?> GetUserInfoAsync(Token token)
    {

        var userInfoUrl = $"/sns/userinfo?access_token={token.AccessToken}&openid={token.OpenId}";

        var response = await _httpClient.GetAsync(userInfoUrl);

        return await response.EnsureSuccessAndDeserializeAsync<UserInfo>();
    }

    public async Task<Token?> RefreshTokenAsync(string refreshToken)
    {
        var refreshTokenUrl = $"/sns/oauth2/refresh_token?appid={_option.AppId}&grant_type=refresh_token&refresh_token={refreshToken}";

        var response = await _httpClient.GetAsync(refreshTokenUrl);

        return await response.EnsureSuccessAndDeserializeAsync<Token>();
    }
}
