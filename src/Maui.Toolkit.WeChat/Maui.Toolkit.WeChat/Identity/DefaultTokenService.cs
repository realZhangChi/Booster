using Microsoft.Extensions.Options;
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
    private readonly HttpClient _httpClinet;
    private readonly WeChatOption _option;

    public DefaultTokenService(
        HttpClient httpClient,
        IOptions<WeChatOption> option)
    {
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
        return token;
    }
}
