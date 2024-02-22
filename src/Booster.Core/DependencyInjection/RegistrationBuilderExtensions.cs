using Autofac.Builder;
using Autofac.Extras.DynamicProxy;
using Booster.DynamicProxy;
using Booster.DynamicProxy.Castle;

namespace Booster.DependencyInjection;

public static class RegistrationBuilderExtensions
{
    public static IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> ConfigureIntercept<TActivatorData,
        TRegistrationStyle>(
        this IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> registrationBuilder,
        ServiceDescriptor descriptor)
    {
        var interceptAttributes =
            descriptor.ImplementationType?.GetCustomAttributes(true).OfType<InterceptByAttribute>().ToArray() ??
            Array.Empty<InterceptByAttribute>();
        var interceptors = interceptAttributes.SelectMany(i => i.GetInterceptors())
            .Select(i => typeof(BoosterAsyncDeterminationInterceptor<>).MakeGenericType(i)).ToArray();
        if (interceptors.Length == 0)
        {
            return registrationBuilder;
        }
        
        if (descriptor.ServiceType.IsInterface)
        {
            registrationBuilder.EnableInterfaceInterceptors();
        }
        else
        {
            (registrationBuilder as IRegistrationBuilder<object, ConcreteReflectionActivatorData, TRegistrationStyle>)?.EnableClassInterceptors();
        }
        
        registrationBuilder.InterceptedBy(interceptors);

        return registrationBuilder;
    }
}