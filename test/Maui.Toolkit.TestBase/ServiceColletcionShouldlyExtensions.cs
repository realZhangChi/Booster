using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Maui.Toolkit.TestBase;

public static class ServiceColletcionShouldlyExtensions
{
    public static void ShouldContainTransient(this IServiceCollection services, Type serviceType, Type? implementationType = null)
    {
        var serviceDescriptor = services.FirstOrDefault(s => s.ServiceType == serviceType);

        serviceDescriptor.ShouldNotBeNull();
        serviceDescriptor.ImplementationType.ShouldBe(implementationType ?? serviceType);
        serviceDescriptor.ImplementationFactory.ShouldBeNull();
        serviceDescriptor.ImplementationInstance.ShouldBeNull();
        serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
    }
}
