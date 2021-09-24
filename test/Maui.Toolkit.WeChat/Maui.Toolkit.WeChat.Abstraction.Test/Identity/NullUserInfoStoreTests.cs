using Maui.Toolkit.WeChat.Identity;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Abstraction.Test.Identity;

public class NullUserInfoStoreTests
{
    private readonly IUserInfoStore _userStore;

    public NullUserInfoStoreTests()
    {
        _userStore = new NullUserInfoStore();
    }

    [Fact]
    public async Task UserInfoShouldBeNull()
    {
        var userInfo = await _userStore.GetOrNullAsync();

        userInfo.ShouldBeNull();
    }

    [Fact]
    public async Task SetTest()
    {
        await _userStore.SetAsync(new UserInfo());
    }
}
