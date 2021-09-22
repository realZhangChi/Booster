using Microsoft.Maui;
using Microsoft.Extensions.DependencyInjection;
using Maui.Toolkit.WeChat.Identity;

namespace Maui.Toolkit.WeChat;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeChat(this IServiceCollection services)
    {
        services.AddTransient<IAuthorizationService, NullAuthorizationService>();
        services.AddTransient<IAuthorizationHandler, NullAuthorizationHandler>();
        services.AddTransient<ITokenService, NullTokenService>();

        return services;
    }
}
