namespace Maui.Toolkit.WeChat.UnitTest;

public class WeChatOption_Tests
{
    [Fact]
    public void Properties_Should_Not_Be_Null_Or_WhiteSpace()
    {
        var appId = "Test_App_Id";
        var appSecret = "Test_App_Secret";

        var option = new WeChatOption(appId, appSecret);

        option.AppId.ShouldNotBeNullOrWhiteSpace();
        option.AppSecret.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Null_AppId_Should_Throw_Exception()
    {
        string? nullAppId = null;
        var appSecret = "Test_App_Secret";

        Assert.Throws<ArgumentNullException>(() => new WeChatOption(nullAppId, appSecret));
    }

    [Fact]
    public void WhiteSpace_AppId_Should_Throw_Exception()
    {
        var whiteSpaceAppId = "   ";
        var appSecret = "Test_App_Secret";

        Assert.Throws<ArgumentNullException>(() => new WeChatOption(whiteSpaceAppId, appSecret));
    }


    [Fact]
    public void Null_AppSecret_Should_Throw_Exception()
    {
        var appId = "Test_App_Id";
        string? nullAppSecret = null;

        Assert.Throws<ArgumentNullException>(() => new WeChatOption(appId, nullAppSecret));
    }

    [Fact]
    public void WhiteSpace_AppSecret_Should_Throw_Exception()
    {
        var appId = "Test_App_Id";
        var whiteSpaceAppSecret = "   ";

        Assert.Throws<ArgumentNullException>(() => new WeChatOption(appId, whiteSpaceAppSecret));
    }

}
