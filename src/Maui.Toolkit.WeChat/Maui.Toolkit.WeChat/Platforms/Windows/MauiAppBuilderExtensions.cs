using Maui.Toolkit.WeChat.Platforms.Windows.Identity;
using Maui.Toolkit.WeChat.Services.Identity;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Maui.Toolkit.WeChat.Platforms.Windows;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddWindows(this IServiceCollection services, WeChatOption option)
    {
        services.Replace(
            new ServiceDescriptor(
                typeof(IAuthorizationHandler),
                typeof(DefaultAuthorizationHandler),
                ServiceLifetime.Transient)
            );

        return services;
    }
}
