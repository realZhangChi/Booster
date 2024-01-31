using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Booster.Dialog;
using Booster.DynamicProxy;
using Booster.DynamicProxy.Castle;
using Booster.ExceptionHandle;
using Booster.MVVM;

namespace Booster.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static MauiAppBuilder UseBooster(this MauiAppBuilder builder, params Assembly[]? includedAssemblies)
    {
        builder.ConfigureContainer(new AutofacServiceProviderFactory((containerBuilder =>
        {
            containerBuilder.Populate(builder.Services);

            _ = containerBuilder
                .RegisterCastleInterceptor()
                .RegisterInterceptors([
                    Assembly.GetExecutingAssembly(), ..includedAssemblies, Assembly.GetEntryAssembly()
                ])
                .RegisterViewModels([
                    ..includedAssemblies, Assembly.GetEntryAssembly()
                ]);

            containerBuilder.RegisterType<DefaultDialogService>().As<IDialogService>().InstancePerDependency();
            containerBuilder.RegisterType<DefaultExceptionNotifier>().As<IExceptionNotifier>().InstancePerDependency();
        })));
        builder.Services.AddTransient<IDialogService, DefaultDialogService>();
        return builder;
    }

    private static ContainerBuilder RegisterViewModels(this ContainerBuilder containerBuilder,
        IEnumerable<Assembly> assembly)
    {
        var viewModels = assembly
            .SelectMany(a => a.GetTypes()
                .Where(x => x is { IsClass: true, IsAbstract: false, IsGenericType: false } &&
                            x.IsAssignableTo(typeof(IViewModelBase))))
            .ToArray();

        foreach (var viewModel in viewModels)
        {
            var vmContainerBuilder = containerBuilder.RegisterType(viewModel)
                .InstancePerDependency()
                .EnableClassInterceptors();

            var interceptAttributes = viewModel.GetCustomAttributes(true).OfType<InterceptByAttribute>().ToArray();
            var interceptors = interceptAttributes.SelectMany(i => i.GetInterceptors())
                .Select(i => typeof(BoosterAsyncDeterminationInterceptor<>).MakeGenericType(i)).ToArray();
            vmContainerBuilder.InterceptedBy(interceptors);
        }

        return containerBuilder;
    }

    private static ContainerBuilder RegisterCastleInterceptor(this ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterGeneric(typeof(BoosterAsyncDeterminationInterceptor<>));
        return containerBuilder;
    }

    private static ContainerBuilder RegisterInterceptors(this ContainerBuilder containerBuilder,
        IEnumerable<Assembly> assembly)
    {
        var interceptors = assembly
            .SelectMany(a => a.GetTypes()
                .Where(x => x is { IsClass: true, IsAbstract: false, IsGenericType: false } &&
                            x.IsAssignableTo(typeof(IBoosterInterceptor))))
            .ToArray();

        containerBuilder.RegisterTypes(interceptors).InstancePerDependency();

        return containerBuilder;
    }
}