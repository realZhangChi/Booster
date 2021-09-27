using Maui.Toolkit.WeChat.Services.Identity;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Abstraction.Test.Identity;

public class NullUserInfoServiceTests
{
    private readonly IUserInfoService _userInfoService;

    public NullUserInfoServiceTests()
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
