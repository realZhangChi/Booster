using Application = Android.App.Application;

namespace Maui.Toolkit.WeChat.Platforms.Android;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAndroid(this IServiceCollection services, WeChatOption option)
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
                typeof(DefaultAuthorizationHandler),
                ServiceLifetime.Transient)
            );

        return services;
    }
}
