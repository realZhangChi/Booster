using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Services.Identity;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Mocks
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
