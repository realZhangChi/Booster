using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Booster.DynamicProxy;
using Booster.DynamicProxy.Castle;
using Booster.ExceptionHandle;
using Booster.MVVM;
using Booster.Service;

namespace Booster.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static MauiAppBuilder UseBooster<TApp>(this MauiAppBuilder builder, params Assembly[]? includedAssemblies)
        where TApp : class, IApplication
    {
        includedAssemblies ??= Array.Empty<Assembly>();
        builder.ConfigureContainer(new AutofacServiceProviderFactory(containerBuilder =>
        {
            containerBuilder.BoosterPopulate(builder.Services);
            
            _ = containerBuilder
                .RegisterCastleInterceptor()
                .RegisterInterceptors([
                    Assembly.GetExecutingAssembly(), ..includedAssemblies, Assembly.GetAssembly(typeof(TApp))
                ])
                .RegisterServices([
                    Assembly.GetExecutingAssembly(), ..includedAssemblies, Assembly.GetAssembly(typeof(TApp))
                ])
                .RegisterViewModels([
                    ..includedAssemblies, Assembly.GetAssembly(typeof(TApp))
                ]);
            
            containerBuilder.RegisterType<DefaultExceptionNotifier>().As<IExceptionNotifier>().InstancePerDependency();
        }));

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
            if (interceptors.Length != 0)
            {
                vmContainerBuilder.InterceptedBy(interceptors);
            }
        }

        return containerBuilder;
    }

    private static ContainerBuilder RegisterServices(this ContainerBuilder containerBuilder,
        IEnumerable<Assembly> assembly)
    {
        var services = assembly
            .SelectMany(a => a.GetTypes()
                .Where(x => x is { IsClass: true, IsAbstract: false, IsGenericType: false } &&
                            x.IsAssignableTo(typeof(IBoosterService))))
            .ToArray();

        foreach (var service in services)
        {
            var @interfaces = service.GetInterfaces()
                .Where(x => x.Name.EndsWith("Service") && service.Name.EndsWith(x.Name.TrimStart('I')))
                .ToArray();
            var serviceContainerBuilder = containerBuilder.RegisterType(service)
                .InstancePerDependency();
            if (@interfaces.Length > 0)
            {
                serviceContainerBuilder = serviceContainerBuilder.As(@interfaces)
                    .EnableInterfaceInterceptors();
            }
            else
            {
                serviceContainerBuilder = serviceContainerBuilder.EnableClassInterceptors();
            }

            var interceptAttributes = service.GetCustomAttributes(true).OfType<InterceptByAttribute>().ToArray();
            var interceptors = interceptAttributes.SelectMany(i => i.GetInterceptors())
                .Select(i => typeof(BoosterAsyncDeterminationInterceptor<>).MakeGenericType(i)).ToArray();
            if (interceptors.Length != 0)
            {
                serviceContainerBuilder.InterceptedBy(interceptors);
            }
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