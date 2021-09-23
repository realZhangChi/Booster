using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public class DefaultUserInfoService : IUserInfoService
{
    private readonly ITokenStore _tokenStore;
    private readonly ITokenService _tokenService;
    private readonly HttpClient _httpClinet;

    public DefaultUserInfoService(
        ITokenStore tokenStore,
        ITokenService tokenService,
        HttpClient httpClient)
    {
        _tokenStore = tokenStore;
        _tokenService = tokenService;
        _httpClinet = httpClient;
    }

    public async Task<UserInfo?> GetUserInfoFromWeChatAsync(string? openId = null)
    {
        var token = await _tokenStore.GetOrNullAsync();
        if (token == null)
        {
            return null;
        }
        // 1200 seconds = 20 minutes
        if (token.IssuedAt + token.ExpiresIn - 1200 > DateTimeOffset.UtcNow.ToUnixTimeSeconds())
        {
            await _tokenService.RefreshTokenAsync();
        }

        var userInfoEndpoint = $"https://api.weixin.qq.com/sns/userinfo?access_token={token.AccessToken}&openid={openId ?? token.OpenId}";

        var response = await _httpClinet.GetAsync(userInfoEndpoint);
        response.EnsureSuccessStatusCode();

        var content = response.Content;
        var userInfo = await JsonSerializer.DeserializeAsync<UserInfo>(await content.ReadAsStreamAsync());
        return userInfo;
    }
}
