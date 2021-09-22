using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public class DefaultAuthorizationService : IAuthorizationService
{
    private readonly IAuthorizationHandler _handler;
    private readonly ITokenService _tokenService;
    private readonly HttpClient _httpClinet;
    private readonly WeChatOption _option;

    public DefaultAuthorizationService(
        IAuthorizationHandler handler,
        ITokenService tokenService,
        HttpClient httpClient,
        IOptions<WeChatOption> option)
    {
        _handler = handler;
        _tokenService = tokenService;
        _httpClinet = httpClient;
        _option = option.Value;
    }
    public virtual Task<bool> AuthorizeAsync()
    {
        return _handler.AuthorizeAsync();
    }

    public virtual async Task AuthorizedAsync(string code)
    {
        var token = await GetTokenAsync(code);
        await _tokenService.SetAsync(token);
        await GetUserInfoAsync();
    }

    protected virtual async Task<Token> GetTokenAsync(string code)
    {
        var tokenEndpoint = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={_option.AppId}&secret={_option.AppSecret}&code={code}&grant_type=authorization_code";

        var response = await _httpClinet.GetAsync(tokenEndpoint);
        response.EnsureSuccessStatusCode();

        var content = response.Content;
        var token = await JsonSerializer.DeserializeAsync<Token>(await content.ReadAsStreamAsync());
        return token;
    }

    protected virtual Task GetUserInfoAsync()
    {
        return Task.CompletedTask;
    }

}
