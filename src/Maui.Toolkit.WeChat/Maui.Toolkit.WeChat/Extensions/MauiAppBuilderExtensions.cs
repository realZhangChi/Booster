using Maui.Toolkit.WeChat.Services.Http;
using Maui.Toolkit.WeChat.Services.Identity;
using Maui.Toolkit.WeChat.ViewModels;
using Maui.Toolkit.WeChat.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;

#if __ANDROID__
using Maui.Toolkit.WeChat.Platforms.Android;
#endif

namespace Maui.Toolkit.WeChat.Extensions;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseWeChat(this MauiAppBuilder builder, WeChatWebOptions webOptions, WeChatMobileOptions mobileOptions)
    {
        builder.Services.AddWeChat();

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

        builder.Services.AddTransient<IWeChatHttpClient, DefaultWeChatHttpClient>();

        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<LoginPage>();

        builder.Services.Replace(
            new ServiceDescriptor(
                typeof(IAuthorizationHandler),
                typeof(DefaultAuthorizationHandler),
                ServiceLifetime.Transient));
        builder.Services.Replace(
            new ServiceDescriptor(
                typeof(IAuthorizationService),
                typeof(DefaultAuthorizationService),
                ServiceLifetime.Transient)
            );
        builder.Services.Replace(
            new ServiceDescriptor(
                typeof(ITokenService),
                typeof(DefaultTokenService),
                ServiceLifetime.Transient)
            );

#if __ANDROID__
        builder.Services.AddAndroid(mobileOptions);
#endif


        builder.Services.AddHttpClient();
        return builder;
    }
}
