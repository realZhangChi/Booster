using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Booster.Core.Dialog;
using Booster.Core.ExceptionHandle;
using Booster.Core.MVVM;

namespace Booster.Core.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static MauiAppBuilder UseBooster(this MauiAppBuilder builder)
    {
        builder.ConfigureContainer(new AutofacServiceProviderFactory((containerBuilder =>
        {
            containerBuilder.Populate(builder.Services);

            containerBuilder.RegisterType<ViewModelAsyncInterceptor>();
            containerBuilder.RegisterType<ViewModelInterceptor>();

            _ = containerBuilder.RegisterViewModels();

            containerBuilder.RegisterType<DefaultDialogService>().As<IDialogService>().InstancePerDependency();
            containerBuilder.RegisterType<DefaultExceptionNotifier>().As<IExceptionNotifier>().InstancePerDependency();
        })));
        builder.Services.AddTransient<IDialogService, DefaultDialogService>();
        return builder;
    }

    private static ContainerBuilder RegisterViewModels(this ContainerBuilder containerBuilder)
    {
        var viewModels = Assembly.GetEntryAssembly()?.GetTypes()
            .Where(x => x is { IsClass: true, IsAbstract: false, IsGenericType: false } &&
                        x.IsAssignableTo(typeof(IViewModelBase)))
            .ToArray();
        if (viewModels is null)
        {
            return containerBuilder;
        }

        foreach (var viewModel in viewModels)
        {
            containerBuilder.RegisterType(viewModel)
                .InstancePerDependency()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(ViewModelInterceptor));
        }

        return containerBuilder;
    }
}