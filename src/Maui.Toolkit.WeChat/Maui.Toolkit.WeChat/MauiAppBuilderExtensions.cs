using Maui.Toolkit.WeChat.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui;
using System;

#if __ANDROID__
using Maui.Toolkit.WeChat.Platforms.Android;
#endif

namespace Maui.Toolkit.WeChat;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseWeChat(this MauiAppBuilder builder, WeChatOption option)
    {
        builder.Services.AddWeChat();

        builder.Services.Configure<WeChatOption>(o => o = option);

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
#endif

        builder.Services.AddHttpClient();
        return builder;
    }
}
