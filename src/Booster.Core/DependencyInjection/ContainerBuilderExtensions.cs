using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Core.Resolving.Pipeline;
using Autofac.Extensions.DependencyInjection;

namespace Booster.DependencyInjection;

public static class ContainerBuilderExtensions
{
    public static void BoosterPopulate(
        this ContainerBuilder builder,
        IEnumerable<ServiceDescriptor> descriptors)
    {
        builder.Populate(Array.Empty<ServiceDescriptor>());
        Register(builder, descriptors, null);
    }

    #region Autofac
    
    // The MIT License (MIT)
    //
    // Copyright (c) 2014 Autofac Project
    //
    // Permission is hereby granted, free of charge, to any person obtaining a copy
    // of this software and associated documentation files (the "Software"), to deal
    // in the Software without restriction, including without limitation the rights
    // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    // copies of the Software, and to permit persons to whom the Software is
    // furnished to do so, subject to the following conditions:
    //
    // The above copyright notice and this permission notice shall be included in all
    // copies or substantial portions of the Software.
    //
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    // SOFTWARE.
    
    # region Autofac ServiceDescriptorExtensions

    // Copy from https://github.com/autofac/Autofac.Extensions.DependencyInjection/blob/develop/src/Autofac.Extensions.DependencyInjection/ServiceDescriptorExtensions.cs

    /// <summary>
    /// Normalizes the implementation instance data between keyed and not keyed services.
    /// </summary>
    /// <param name="descriptor">
    /// The <see cref="ServiceDescriptor"/> to normalize.
    /// </param>
    /// <returns>
    /// The appropriate implementation instance from the service descriptor.
    /// </returns>
    static object? NormalizedImplementationInstance(this ServiceDescriptor descriptor) => descriptor.IsKeyedService
        ? descriptor.KeyedImplementationInstance
        : descriptor.ImplementationInstance;

    // Copy from https://github.com/autofac/Autofac.Extensions.DependencyInjection/blob/aa5edfeb4bdc35807b78d146f7e3fc2cb98076ac/src/Autofac.Extensions.DependencyInjection/ServiceDescriptorExtensions.cs#L33
    /// <summary>
    /// Normalizes the implementation type data between keyed and not keyed services.
    /// </summary>
    /// <param name="descriptor">
    /// The <see cref="ServiceDescriptor"/> to normalize.
    /// </param>
    /// <returns>
    /// The appropriate implementation type from the service descriptor.
    /// </returns>
    static Type? NormalizedImplementationType(this ServiceDescriptor descriptor) => descriptor.IsKeyedService
        ? descriptor.KeyedImplementationType
        : descriptor.ImplementationType;

    # endregion

    # region AutofacRegistration
    
    // https://github.com/autofac/Autofac.Extensions.DependencyInjection/blob/develop/src/Autofac.Extensions.DependencyInjection/AutofacRegistration.cs

    /// <summary>
    /// Configures the exposed service type on a service registration.
    /// </summary>
    /// <typeparam name="TActivatorData">The activator data type.</typeparam>
    /// <typeparam name="TRegistrationStyle">The object registration style.</typeparam>
    /// <param name="registrationBuilder">The registration being built.</param>
    /// <param name="descriptor">The service descriptor with service type and key information.</param>
    /// <returns>
    /// The <paramref name="registrationBuilder" />, configured with the proper service type,
    /// and available for additional configuration.
    /// </returns>
    private static IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> ConfigureServiceType<TActivatorData,
        TRegistrationStyle>(
        this IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> registrationBuilder,
        ServiceDescriptor descriptor)
    {
        if (descriptor.IsKeyedService)
        {
            var key = descriptor.ServiceKey!;

            // If it's keyed, the service key won't be null. A null key results in it _not_ being a keyed service.
            registrationBuilder.Keyed(key, descriptor.ServiceType);
        }
        else
        {
            registrationBuilder.As(descriptor.ServiceType);
        }

        return registrationBuilder;
    }

    /// <summary>
    /// Configures the lifecycle on a service registration.
    /// </summary>
    /// <typeparam name="TActivatorData">The activator data type.</typeparam>
    /// <typeparam name="TRegistrationStyle">The object registration style.</typeparam>
    /// <param name="registrationBuilder">The registration being built.</param>
    /// <param name="lifecycleKind">The lifecycle specified on the service registration.</param>
    /// <param name="lifetimeScopeTagForSingleton">
    /// If not <see langword="null"/> then all registrations with lifetime <see cref="ServiceLifetime.Singleton" /> are registered
    /// using <see cref="IRegistrationBuilder{TLimit,TActivatorData,TRegistrationStyle}.InstancePerMatchingLifetimeScope" />
    /// with provided <paramref name="lifetimeScopeTagForSingleton"/>
    /// instead of using <see cref="IRegistrationBuilder{TLimit,TActivatorData,TRegistrationStyle}.SingleInstance"/>.
    /// </param>
    /// <returns>
    /// The <paramref name="registrationBuilder" />, configured with the proper lifetime scope,
    /// and available for additional configuration.
    /// </returns>
    private static IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> ConfigureLifecycle<TActivatorData,
        TRegistrationStyle>(
        this IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> registrationBuilder,
        ServiceLifetime lifecycleKind,
        object? lifetimeScopeTagForSingleton)
    {
        switch (lifecycleKind)
        {
            case ServiceLifetime.Singleton:
                if (lifetimeScopeTagForSingleton == null)
                {
                    registrationBuilder.SingleInstance();
                }
                else
                {
                    registrationBuilder.InstancePerMatchingLifetimeScope(lifetimeScopeTagForSingleton);
                }

                break;
            case ServiceLifetime.Scoped:
                registrationBuilder.InstancePerLifetimeScope();
                break;
            case ServiceLifetime.Transient:
                registrationBuilder.InstancePerDependency();
                break;
        }

        return registrationBuilder;
    }

    // Copy from https://github.com/autofac/Autofac.Extensions.DependencyInjection/blob/aa5edfeb4bdc35807b78d146f7e3fc2cb98076ac/src/Autofac.Extensions.DependencyInjection/AutofacRegistration.cs#L182
    /// <summary>
    /// Populates the Autofac container builder with the set of registered service descriptors.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="ContainerBuilder"/> into which the registrations should be made.
    /// </param>
    /// <param name="descriptors">
    /// The set of service descriptors to register in the container.
    /// </param>
    /// <param name="lifetimeScopeTagForSingletons">
    /// If not <see langword="null"/> then all registrations with lifetime <see cref="ServiceLifetime.Singleton" /> are registered
    /// using <see cref="IRegistrationBuilder{TLimit,TActivatorData,TRegistrationStyle}.InstancePerMatchingLifetimeScope" />
    /// with provided <paramref name="lifetimeScopeTagForSingletons"/>
    /// instead of using <see cref="IRegistrationBuilder{TLimit,TActivatorData,TRegistrationStyle}.SingleInstance"/>.
    /// </param>
    [SuppressMessage("CA2000", "CA2000",
        Justification = "Registrations created here are disposed when the built container is disposed.")]
    private static void Register(
        ContainerBuilder builder,
        IEnumerable<ServiceDescriptor> descriptors,
        object? lifetimeScopeTagForSingletons)
    {
        foreach (var descriptor in descriptors)
        {
            var implementationType = descriptor.NormalizedImplementationType();
            if (implementationType != null)
            {
                // Test if the an open generic type is being registered
                var serviceTypeInfo = descriptor.ServiceType.GetTypeInfo();
                if (serviceTypeInfo.IsGenericTypeDefinition)
                {
                    builder
                        .RegisterGeneric(implementationType)
                        .ConfigureServiceType(descriptor)
                        .ConfigureLifecycle(descriptor.Lifetime, lifetimeScopeTagForSingletons)
                        .ConfigureIntercept(descriptor);
                }
                else
                {
                    builder
                        .RegisterType(implementationType)
                        .ConfigureServiceType(descriptor)
                        .ConfigureLifecycle(descriptor.Lifetime, lifetimeScopeTagForSingletons)
                        .ConfigureIntercept(descriptor);
                }

                continue;
            }

            if (descriptor.IsKeyedService && descriptor.KeyedImplementationFactory != null)
            {
                var registration = RegistrationBuilder.ForDelegate(descriptor.ServiceType, (context, parameters) =>
                    {
                        // At this point the context is always a ResolveRequestContext, which will expose the actual service type.
                        var requestContext = (ResolveRequestContext)context;

                        var serviceProvider = context.Resolve<IServiceProvider>();

                        var keyedService = (Autofac.Core.KeyedService)requestContext.Service;

                        var key = keyedService.ServiceKey;

                        return descriptor.KeyedImplementationFactory(serviceProvider, key);
                    })
                    .ConfigureServiceType(descriptor)
                    .ConfigureLifecycle(descriptor.Lifetime, lifetimeScopeTagForSingletons)
                    .CreateRegistration();

                builder.RegisterComponent(registration);

                continue;
            }
            else if (!descriptor.IsKeyedService && descriptor.ImplementationFactory != null)
            {
                var registration = RegistrationBuilder.ForDelegate(descriptor.ServiceType, (context, parameters) =>
                    {
                        var serviceProvider = context.Resolve<IServiceProvider>();
                        return descriptor.ImplementationFactory(serviceProvider);
                    })
                    .ConfigureServiceType(descriptor)
                    .ConfigureLifecycle(descriptor.Lifetime, lifetimeScopeTagForSingletons)
                    .CreateRegistration();

                builder.RegisterComponent(registration);
                continue;
            }

            // It's not a type or factory, so it must be an instance.
            builder
                .RegisterInstance(descriptor.NormalizedImplementationInstance()!)
                .ConfigureServiceType(descriptor)
                .ConfigureLifecycle(descriptor.Lifetime, null);
        }
    }

    #endregion
    
    #endregion
}