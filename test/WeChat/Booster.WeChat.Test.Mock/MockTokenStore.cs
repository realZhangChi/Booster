using Booster.WeChat.Models.Identity;
using Booster.WeChat.Services.Identity;

namespace Booster.WeChat.Test.Mock
{
    public class MockTokenStore : ITokenStore
    {
        private static Token? _token;

        public Task<Token?> GetOrNullAsync() => Task.FromResult(_token);

        public Task SetAsync(Token token)
        {
            _token = token;
            return Task.CompletedTask;
        }
    }
}
