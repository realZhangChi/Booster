using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using IdentityModel.Client;
using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Http;

public class DefaultWeChatHttpClient : IWeChatHttpClient
{
    private readonly HttpClient _httpClient;

    public const string BaseAddress = "https://api.weixin.qq.com";
    public const string AccessTokenPath = "/sns/oauth2/access_token";
    public const string UserInfoPath = "/sns/userinfo";
    public const string RefreshTokenPath = "/sns/oauth2/refresh_token";

    public DefaultWeChatHttpClient(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Token> GetTokenAsync(string appId, string appSecret, string code)
    {
        if (string.IsNullOrWhiteSpace(appId))
            throw new ArgumentNullException(nameof(appId));
        if (string.IsNullOrWhiteSpace(appSecret))
            throw new ArgumentNullException(nameof(appSecret));
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentNullException(nameof(code));

        var uri = $"{AccessTokenPath}?appid={appId}&secret={appSecret}&code={code}&grant_type=authorization_code";
        var response = await _httpClient.GetAsync(uri);

        var content = await response.Content.ReadAsStringAsync();
        CheckErrorCode(content);

        return JsonSerializer.Deserialize<Token>(content)!;
    }

    public async Task<UserInfo> GetUserInfoAsync(string accessToken, string openId)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
            throw new ArgumentNullException(nameof(accessToken));
        if (string.IsNullOrWhiteSpace(openId))
            throw new ArgumentNullException(nameof(openId));

        var uri = $"{UserInfoPath}?access_token={accessToken}&openid={openId}";
        var response = await _httpClient.GetAsync(uri);

        var content = await response.Content.ReadAsStringAsync();
        CheckErrorCode(content);

        return JsonSerializer.Deserialize<UserInfo>(content)!;
    }

    public async Task<Token> RefreshTokenAsync(string appId, string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(appId))
            throw new ArgumentNullException(nameof(appId));
        if (string.IsNullOrWhiteSpace(refreshToken))
            throw new ArgumentNullException(nameof(refreshToken));

        var uri = $"{RefreshTokenPath}?appid={appId}&grant_type=refresh_token&refresh_token={refreshToken}";
        var response = await _httpClient.GetAsync(uri);

        var content = await response.Content.ReadAsStringAsync();
        CheckErrorCode(content);

        return JsonSerializer.Deserialize<Token>(content)!;
    }

    private static void CheckErrorCode(string weChatContent)
    {
        using var jsonDoc = JsonDocument.Parse(weChatContent);

        var hasErrorCode = jsonDoc.RootElement.TryGetProperty("errcode", out var errorCodeElement);
        if (hasErrorCode)
        {
            var errorCode = errorCodeElement.GetInt32();
            if (errorCode != 0)
            {
                throw new HttpRequestException(jsonDoc.RootElement.ToString());
            }
        }
    }
}
