﻿using Microsoft.Extensions.Options;
using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

internal class DefaultTokenService : ITokenService
{
    private readonly ITokenStore _tokenStore;
    private readonly HttpClient _httpClinet;
    private readonly WeChatOption _option;

    public DefaultTokenService(
        ITokenStore tokenStore,
        HttpClient httpClient,
        IOptions<WeChatOption> option)
    {
        _tokenStore = tokenStore;
        _httpClinet = httpClient;
        _option = option.Value;
    }

    public virtual async Task<Token?> GetTokenFromWeChatAsync(string code)
    {
        var tokenEndpoint = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={_option.AppId}&secret={_option.AppSecret}&code={code}&grant_type=authorization_code";

        var response = await _httpClinet.GetAsync(tokenEndpoint);
        response.EnsureSuccessStatusCode();

        var content = response.Content;
        var token = await JsonSerializer.DeserializeAsync<Token>(await content.ReadAsStreamAsync());
        if (token is not null)
        {
            token.IssuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        return token;
    }

    public async Task<Token?> RefreshTokenAsync()
    {
        var token = await _tokenStore.GetOrNullAsync();
        if (token is null || string.IsNullOrWhiteSpace(token.RefreshToken))
        {
            // TODO: NULL token exception
            throw new NotImplementedException();
        }
        // 2419200 seconds = 28 days
        if (token.IssuedAt + 2419200 > DateTimeOffset.UtcNow.ToUnixTimeSeconds())
        {
            // TODO: refresh_token expired exception
            throw new NotImplementedException();
        }

        var refreshTokenEndpoint = $"https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={_option.AppId}&grant_type=refresh_token&refresh_token={token.RefreshToken}";

        var response = await _httpClinet.GetAsync(refreshTokenEndpoint);
        response.EnsureSuccessStatusCode();

        var content = response.Content;
        var refreshedToken = await JsonSerializer.DeserializeAsync<Token>(await content.ReadAsStreamAsync());
        if (refreshedToken is not null)
        {
            refreshedToken.IssuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        return refreshedToken;
    }
}
