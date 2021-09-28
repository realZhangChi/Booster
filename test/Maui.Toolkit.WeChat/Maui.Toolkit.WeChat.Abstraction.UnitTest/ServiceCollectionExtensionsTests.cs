

namespace Maui.Toolkit.WeChat.Abstraction.UnitTest;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void ShouldRegisterNullImplementions()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddWeChat();

        serviceCollection.ShouldContainTransient(typeof(IAuthorizationService), typeof(NullAuthorizationService));
        serviceCollection.ShouldContainTransient(typeof(IAuthorizationHandler), typeof(NullAuthorizationHandler));
        serviceCollection.ShouldContainTransient(typeof(ITokenService), typeof(NullTokenService));
        serviceCollection.ShouldContainTransient(typeof(ITokenStore), typeof(NullTokenStore));
        serviceCollection.ShouldContainTransient(typeof(IUserInfoService), typeof(NullUserInfoService));
        serviceCollection.ShouldContainTransient(typeof(IUserInfoStore), typeof(NullUserInfoStore));
    }
}
