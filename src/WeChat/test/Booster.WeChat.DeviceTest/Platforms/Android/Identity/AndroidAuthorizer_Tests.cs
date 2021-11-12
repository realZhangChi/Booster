using Booster.WeChat.Services.Identity;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;

using Shouldly;

using System.Threading.Tasks;

using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.Identity
{
    public class AndroidAuthorizer_Tests
    {
        [Fact]
        public async Task Authorize_Should_Return_False()
        {
            var authorizationHandler = MauiApplication.Current.Services.GetRequiredService<IPlatformAuthorizer>();
            var result = await authorizationHandler.AuthorizeAsync();

            result.ShouldBeFalse();
        }
    }
}
