using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Services.Identity;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Mocks
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
