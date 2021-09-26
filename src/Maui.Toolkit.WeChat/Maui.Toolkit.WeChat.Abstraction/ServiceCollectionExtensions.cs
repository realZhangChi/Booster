using Microsoft.Maui;
using Microsoft.Extensions.DependencyInjection;
using Maui.Toolkit.WeChat.Services.Identity;

namespace Maui.Toolkit.WeChat;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeChat(this IServiceCollection services)
    {
        services.AddTransient<IAuthorizationService, NullAuthorizationService>();
        services.AddTransient<IAuthorizationHandler, NullAuthorizationHandler>();
        services.AddTransient<ITokenService, NullTokenService>();
        services.AddTransient<ITokenStore, NullTokenStore>();
        services.AddTransient<IUserInfoService, NullUserInfoService>();
        services.AddTransient<IUserInfoStore, NullUserInfoStore>();

        return services;
    }
}
