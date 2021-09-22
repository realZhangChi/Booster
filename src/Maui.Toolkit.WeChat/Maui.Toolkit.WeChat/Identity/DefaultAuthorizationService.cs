using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public class DefaultAuthorizationService : IAuthorizationService
{
    private readonly IAuthorizationHandler _handler;
    private readonly ITokenService _tokenService;
    private readonly HttpClient _httpClinet;

    public DefaultAuthorizationService(
        IAuthorizationHandler handler,
        ITokenService tokenService,
        HttpClient httpClient)
    {
        _handler = handler;
        _tokenService = tokenService;
        _httpClinet = httpClient;
    }
    public Task<bool> AuthorizeAsync()
    {
        return _handler.AuthorizeAsync();
    }

    public Task GetTokenAsync(string code)
    {
        throw new NotImplementedException();
    }
}
