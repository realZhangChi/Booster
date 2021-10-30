using Booster.WeChat.Models.Identity;
using Booster.WeChat.Services.Identity;
using System.Threading.Tasks;

namespace Booster.WeChat.Mocks
{
    internal class MockTokenStore : ITokenStore
    {
        private static Token? _token = null;

        public Task<Token?> GetOrNullAsync() => Task.FromResult(_token);

        public Task SetAsync(Token token)
        {
            _token = token;
            return Task.CompletedTask;
        }
    }
}
