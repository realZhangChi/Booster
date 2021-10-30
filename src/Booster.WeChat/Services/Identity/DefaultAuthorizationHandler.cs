using System;
using System.Threading.Tasks;

using Booster.WeChat.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace Booster.WeChat.Services.Identity;

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
        if (Application.Current is not null && Application.Current.MainPage is not null)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(loginPage);
            return true;
        }

        return false;
    }
}

