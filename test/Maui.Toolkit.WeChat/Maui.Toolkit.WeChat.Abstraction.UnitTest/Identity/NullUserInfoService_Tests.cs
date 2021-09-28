namespace Maui.Toolkit.WeChat.Abstraction.UnitTest.Identity;

public class NullUserInfoService_Tests
{
    private readonly IUserInfoService _userInfoService;

    public NullUserInfoService_Tests()
    {
        _userInfoService = new NullUserInfoService();
    }

    [Fact]
    public async Task UserInfoShouldBeNull()
    {
        var userInfo = await _userInfoService.GetUserInfoFromWeChatAsync();

        userInfo.ShouldBeNull();
    }
}
