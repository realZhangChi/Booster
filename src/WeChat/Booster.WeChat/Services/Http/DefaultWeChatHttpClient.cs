using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using IdentityModel.Client;
using Booster.WeChat.Models.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Booster.WeChat.Services.Http;

public class DefaultWeChatHttpClient : IWeChatHttpClient
{
    private readonly ILogger _logger;
    private readonly HttpClient _httpClient;

    public const string BaseAddress = "https://api.weixin.qq.com";
    public const string AccessTokenPath = "/sns/oauth2/access_token";
    public const string UserInfoPath = "/sns/userinfo";
    public const string RefreshTokenPath = "/sns/oauth2/refresh_token";

    public DefaultWeChatHttpClient(
        HttpClient httpClient,
        ILogger<DefaultWeChatHttpClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Token?> GetTokenAsync(string appId, string appSecret, string code)
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

        return DeserializeToken(content);
    }

    public async Task<UserInfo?> GetUserInfoAsync(string accessToken, string openId)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
            throw new ArgumentNullException(nameof(accessToken));
        if (string.IsNullOrWhiteSpace(openId))
            throw new ArgumentNullException(nameof(openId));

        var uri = $"{UserInfoPath}?access_token={accessToken}&openid={openId}";
        var response = await _httpClient.GetAsync(uri);

        var content = await response.Content.ReadAsStringAsync();
        CheckErrorCode(content);

        return DeserializeUserInfo(content);
    }

    public async Task<Token?> RefreshTokenAsync(string appId, string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(appId))
            throw new ArgumentNullException(nameof(appId));
        if (string.IsNullOrWhiteSpace(refreshToken))
            throw new ArgumentNullException(nameof(refreshToken));

        var uri = $"{RefreshTokenPath}?appid={appId}&grant_type=refresh_token&refresh_token={refreshToken}";
        var response = await _httpClient.GetAsync(uri);

        var content = await response.Content.ReadAsStringAsync();
        CheckErrorCode(content);

        return DeserializeToken(content);
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

    private Token? DeserializeToken(string content)
    {
        try
        {
            using var jsonDoc = JsonDocument.Parse(content);
            var accessToken = jsonDoc.RootElement.TryGetString("access_token");
            var refreshToken = jsonDoc.RootElement.TryGetString("refresh_token");
            var openId = jsonDoc.RootElement.TryGetString("openid");
            var scope = jsonDoc.RootElement.TryGetString("scope");
            jsonDoc.RootElement.TryGetValue("expires_in").TryGetInt32(out var expiresIn);

            return new Token(
                accessToken,
                expiresIn,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                refreshToken,
                openId,
                scope);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to deserialize the response content into Token class!");
            return null;
        }
    }

    private UserInfo? DeserializeUserInfo(string content)
    {
        try
        {
            using var jsonDoc = JsonDocument.Parse(content);
            var openId = jsonDoc.RootElement.TryGetString("openid");
            var nickName = jsonDoc.RootElement.TryGetString("nickname");
            var country = jsonDoc.RootElement.TryGetString("country");
            var province = jsonDoc.RootElement.TryGetString("province");
            var city = jsonDoc.RootElement.TryGetString("city");
            var headImgUrl = jsonDoc.RootElement.TryGetString("headimgurl");
            var unionId = jsonDoc.RootElement.TryGetString("unionid");

            jsonDoc.RootElement.TryGetProperty("privilege", out var privilegeProperty);
            var privilege = (List<string>)privilegeProperty.Deserialize(typeof(List<string>))!;

            jsonDoc.RootElement.TryGetValue("sex").TryGetInt32(out var sexInt);
            var sex = (Sex)sexInt;

            return new UserInfo(
                openId,
                nickName,
                sex,
                country,
                province,
                city,
                headImgUrl,
                privilege,
                unionId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to deserialize the response content into Token class!");
            return null;
        }
    }
}
