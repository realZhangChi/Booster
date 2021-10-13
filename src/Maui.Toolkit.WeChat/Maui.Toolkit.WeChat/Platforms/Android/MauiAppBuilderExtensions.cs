using System;

using Com.Tencent.MM.Opensdk.Openapi;

using Maui.Toolkit.WeChat.Extensions;
using Maui.Toolkit.WeChat.Platforms.Android.Identity;
using Maui.Toolkit.WeChat.Services.Identity;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Application = Android.App.Application;

namespace Maui.Toolkit.WeChat.Platforms.Android;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAndroid(this IServiceCollection services, WeChatMobileOptions option)
    {
        services.AddTransient(provider =>
        {
            var api = WXAPIFactory.CreateWXAPI(Application.Context, option.AppId, true);
            if (api is null)
            {
                // TODO: best practice
                throw new NotImplementedException();
            }
            api.RegisterApp(option?.AppId);
            return api;
        });

        services.Replace(
            new ServiceDescriptor(
                typeof(IAuthorizationHandler),
                typeof(AndroidAuthorizationHandler),
                ServiceLifetime.Transient)
            );

        return services;
    }
}
