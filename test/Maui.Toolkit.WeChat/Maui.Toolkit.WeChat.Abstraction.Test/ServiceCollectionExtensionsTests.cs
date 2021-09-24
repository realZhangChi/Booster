using Maui.Toolkit.TestBase;
using Maui.Toolkit.WeChat.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Abstraction.Test;

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
