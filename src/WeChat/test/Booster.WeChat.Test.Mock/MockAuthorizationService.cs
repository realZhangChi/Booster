using Booster.WeChat.Services.Identity;

namespace Booster.WeChat.Test.Mock
{
    public class MockAuthorizationService : IAuthorizationService
    {
        public Task<bool> AuthorizeAsync()
        {
            return Task.FromResult(false);
        }

        public Task AuthorizeCallbackAsync(string appId, string appSecret, string code)
        {
            return Task.CompletedTask;
        }
    }
}