using System;
using Maui.Toolkit.WeChat.Views;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Maui.Toolkit.WeChat.Services.Identity;

namespace Maui.Toolkit.WeChat.Platforms.Windows.Identity;

public class DefaultAuthorizationHandler : IAuthorizationHandler
{
    private readonly IServiceProvider _serviceProvider;

    public DefaultAuthorizationHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task<bool> AuthorizeAsync()
    {
        var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
        await Application.Current?.MainPage?.Navigation.PushModalAsync(loginPage);
        return true;
    }
}
