using Maui.Toolkit.WeChat.Services.Http;
using Maui.Toolkit.WeChat.Services.Identity;
using Maui.Toolkit.WeChat.ViewModels;
using Maui.Toolkit.WeChat.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;

#if __ANDROID__
using Maui.Toolkit.WeChat.Platforms.Android;
#elif WINDOWS
using Maui.Toolkit.WeChat.Platforms.Windows;
#endif

namespace Maui.Toolkit.WeChat;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseWeChat(this MauiAppBuilder builder, WeChatOption option)
    {
        builder.Services.AddWeChat();

        builder.Services.Configure<WeChatOption>(o => o = option);
        builder.Services.Configure<WeChatWebOption>(o => o = new WeChatWebOption(option.AppId, option.AppSecret, "test"));

        builder.Services.AddTransient<IWeChatHttpClient, DefaultWeChatHttpClient>();

        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<LoginPage>();

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
        builder.Services.AddAndroid(option);
#elif WINDOWS
        builder.Services.AddWindows(option);
#endif


        builder.Services.AddHttpClient();
        return builder;
    }
}
