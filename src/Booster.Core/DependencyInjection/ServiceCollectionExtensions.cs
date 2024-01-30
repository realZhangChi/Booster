using Booster.Core.Dialog;

namespace Booster.Core.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBooster(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IDialogService, DefaultDialogService>();
        return serviceCollection;
    }
}