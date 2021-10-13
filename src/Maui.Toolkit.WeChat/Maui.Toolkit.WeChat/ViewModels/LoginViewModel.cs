using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Extensions.Options;
using Microsoft.Maui.Controls;

namespace Maui.Toolkit.WeChat.ViewModels;

public class LoginViewModel
{
    private readonly WeChatWebOption _options;
    private readonly IServiceProvider _service;

    private const string AuthUrl = "https://open.weixin.qq.com/connect/qrconnect";

    public string LoginUrl { get; init; }

    public LoginViewModel(
        IOptions<WeChatWebOption> options,
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
        //if (unescapedUrl.Contains(_options.RedirectUrl))
        //{
        //    var authResponse = new AuthorizeResponse(url);
        //    if (!string.IsNullOrWhiteSpace(authResponse.Code))
        //    {
        //        var authorizationService = _service.GetRequiredService<IAuthorizationService>();
        //        await authorizationService.AuthorizeCallbackAsync(authResponse.Code);
        //    }
        //}
    }
}