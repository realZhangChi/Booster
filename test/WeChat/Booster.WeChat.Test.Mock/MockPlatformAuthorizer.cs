using Booster.WeChat.Services.Identity;

namespace Booster.WeChat.Test.Mock
{
    public class MockPlatformAuthorizer : IPlatformAuthorizer
    {
        public Task<bool> AuthorizeAsync()
        {
            return Task.FromResult(true);
        }
    }
}
