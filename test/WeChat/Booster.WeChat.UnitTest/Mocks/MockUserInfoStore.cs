using Booster.WeChat.Models.Identity;
using Booster.WeChat.Services.Identity;
using System.Threading.Tasks;

namespace Booster.WeChat.Mocks
{
    internal class MockUserInfoStore : IUserInfoStore
    {
        private static UserInfo? _userInfo = null;

        public Task<UserInfo?> GetOrNullAsync() => Task.FromResult(_userInfo);

        public Task SetAsync(UserInfo userInfo)
        {
            _userInfo = userInfo;
            return Task.CompletedTask;
        }
    }
}
