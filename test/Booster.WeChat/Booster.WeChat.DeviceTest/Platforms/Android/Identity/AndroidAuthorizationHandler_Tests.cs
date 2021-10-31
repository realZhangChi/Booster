using Booster.WeChat.Services.Identity;

using Shouldly;

using System.Threading.Tasks;
using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.Identity
{
    public class AndroidAuthorizationHandler_Tests
    {
        private readonly IAuthorizationHandler _authorizationHandler;

        public AndroidAuthorizationHandler_Tests(IAuthorizationHandler authorizationHandler)
        {
            _authorizationHandler = authorizationHandler;
        }

        [Fact]
        public async Task Authorize_Should_Return_False()
        {
            var result = await _authorizationHandler.AuthorizeAsync();

            result.ShouldBeFalse();
        }
    }
}
