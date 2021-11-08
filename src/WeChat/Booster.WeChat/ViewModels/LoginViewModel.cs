using System;
using System.Threading.Tasks;
using System.Windows.Input;

using IdentityModel.Client;

using Booster.WeChat.Extensions;
using Booster.WeChat.Services.Identity;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Maui.Controls;

namespace Booster.WeChat.ViewModels;

public class LoginViewModel
{
    private readonly WeChatWebOptions _options;
    private readonly IServiceProvider _service;

    private const string AuthUrl = "https://open.weixin.qq.com/connect/qrconnect";

    public string LoginUrl { get; init; }

    public LoginViewModel(
        IOptions<WeChatWebOptions> options,
        IServiceProvider service)
    {
        _options = options.Value;
        _service = service;
        LoginUrl = $"{AuthUrl}?appid={_options.AppId}&redirect_uri={_options.RedirectUrl}&response_type=code&scope=snsapi_login&state=STATE#wechat_redirect";
    }

    public ICommand NavigateCommand => new Command<string>(async (url) => await NavigateAsync(url));

    private async Task NavigateAsync(string url)
    {
        var unescapedUrl = System.Net.WebUtility.UrlDecode(url);
        if (unescapedUrl.Contains(_options.RedirectUrl))
        {
            var authResponse = new AuthorizeResponse(url);
            if (!string.IsNullOrWhiteSpace(authResponse.Code))
            {
                var authorizationService = _service.GetRequiredService<IAuthorizationService>();
                await authorizationService.AuthorizeCallbackAsync(_options.AppId, _options.AppSecret, authResponse.Code);
                if (Application.Current is not null && Application.Current.MainPage is not null)
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
            }
        }
    }
}