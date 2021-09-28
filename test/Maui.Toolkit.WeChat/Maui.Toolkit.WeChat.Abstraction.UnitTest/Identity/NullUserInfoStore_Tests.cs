namespace Maui.Toolkit.WeChat.Abstraction.UnitTest.Identity;

public class NullUserInfoStore_Tests
{
    private readonly IUserInfoStore _userStore;

    public NullUserInfoStore_Tests()
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
