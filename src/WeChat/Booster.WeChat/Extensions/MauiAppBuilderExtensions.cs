using System;

using Booster.WeChat.Services.Http;
using Booster.WeChat.Services.Identity;
using Booster.WeChat.Services.Share;
using Booster.WeChat.ViewModels;
using Booster.WeChat.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;

#if __ANDROID__
using Booster.WeChat.Platforms.Android;
using Booster.WeChat.Platforms.Android.Identity;
using Booster.WeChat.Platforms.Android.Share;
using Booster.WeChat.Platforms.Android.WeChatApi;

using Com.Tencent.MM.Opensdk.Openapi;

using Application = Android.App.Application;
#endif

namespace Booster.WeChat.Extensions;

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
        builder.Services.AddTransient<ITokenStore, DefaultTokenStore>();
        builder.Services.AddTransient<IUserInfoStore, DefaultUserInfoStore>();

        builder.Services.AddTransient<IShareService, DefaultShareService>();
        builder.Services.AddTransient<IShareHandler, DefaultShareHandler>();

#if __ANDROID__
        builder.Services.AddTransient<IResponseProcessor, DefaultResponseHandler>();
        builder.Services.AddTransient<IResponseProcessor, AuthorizationResponseProcessor>();
        builder.Services.AddTransient<IResponseProcessorResolver, DefaultResponseResponseProcessorResolver>();
        builder.Services.AddTransient<IResponseManager, DefaultResponseManager>();

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
            
        builder.Services.Replace(
            new ServiceDescriptor(
                typeof(IShareHandler),
                typeof(AndroidShareHandler),
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
           })
           .ValidateDataAnnotations();
        builder.Services.AddOptions<WeChatMobileOptions>()
            .Configure(options =>
            {
                options.AppId = mobileOptions.AppId;
                options.AppSecret = mobileOptions.AppSecret;
            })
           .ValidateDataAnnotations();
    }
}
