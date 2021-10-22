using System;

using Maui.Toolkit.WeChat.Services.Http;
using Maui.Toolkit.WeChat.Services.Identity;
using Maui.Toolkit.WeChat.ViewModels;
using Maui.Toolkit.WeChat.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;

#if __ANDROID__
using Maui.Toolkit.WeChat.Platforms.Android;
using Maui.Toolkit.WeChat.Platforms.Android.Identity;

using Com.Tencent.MM.Opensdk.Openapi;

using Application = Android.App.Application;
#endif

namespace Maui.Toolkit.WeChat.Extensions;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseWeChat(this MauiAppBuilder builder, WeChatWebOptions webOptions, WeChatMobileOptions mobileOptions)
    {
        ConfigureOptions(builder, webOptions, mobileOptions);

        AddServices(builder, mobileOptions);

        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<LoginPage>();

        return builder;
    }

    private static void AddServices(MauiAppBuilder builder, WeChatMobileOptions mobileOptions)
    {
        builder.Services.AddHttpClient<IWeChatHttpClient, DefaultWeChatHttpClient>(client =>
        {
            client.BaseAddress = new Uri(DefaultWeChatHttpClient.BaseAddress);
        });

        builder.Services.AddTransient<IWeChatHttpClient, DefaultWeChatHttpClient>();

        builder.Services.AddTransient<IAuthorizationHandler, DefaultAuthorizationHandler>();
        builder.Services.AddTransient<IAuthorizationService, DefaultAuthorizationService>();
        builder.Services.AddTransient<ITokenService, DefaultTokenService>();
        builder.Services.AddTransient<ITokenStore, DefaultTokenStore>();
        builder.Services.AddTransient<IUserInfoService, DefaultUserInfoService>();
        builder.Services.AddTransient<IUserInfoStore, DefaultUserInfoStore>();

#if __ANDROID__
        builder.Services.AddTransient(provider =>
        {
            var api = WXAPIFactory.CreateWXAPI(Application.Context, mobileOptions.AppId, true);
            if (api is null)
            {
                // TODO: best practice
                throw new NotImplementedException();
            }
            api.RegisterApp(mobileOptions?.AppId);
            return api;
        });

        builder.Services.Replace(
            new ServiceDescriptor(
                typeof(IAuthorizationHandler),
                typeof(AndroidAuthorizationHandler),
                ServiceLifetime.Transient)
            );
#endif

    }

    private static void ConfigureOptions(MauiAppBuilder builder, WeChatWebOptions webOptions, WeChatMobileOptions mobileOptions)
    {
        builder.Services.AddOptions<WeChatWebOptions>()
           .Configure(options =>
           {
               options.AppId = webOptions.AppId;
               options.AppSecret = webOptions.AppSecret;
               options.RedirectUrl = webOptions.RedirectUrl;
           });
        builder.Services.AddOptions<WeChatMobileOptions>()
            .Configure(options =>
            {
                options.AppId = mobileOptions.AppId;
                options.AppSecret = mobileOptions.AppSecret;
            });
    }
}
