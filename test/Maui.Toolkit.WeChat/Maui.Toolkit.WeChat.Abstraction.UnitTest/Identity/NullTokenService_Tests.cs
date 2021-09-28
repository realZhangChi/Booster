namespace Maui.Toolkit.WeChat.Abstraction.UnitTest.Identity;

public class NullTokenService_Tests
{
    private readonly ITokenService _tokenService;

    public NullTokenService_Tests()
    {
        _tokenService = new NullTokenService();
    }

    [Fact]
    public async Task Get_Token_Should_Return_Null()
    {
        var code = string.Empty;
        var result = await _tokenService.GetTokenFromWeChatAsync(code);

        result.ShouldBeNull();
    }

    [Fact]
    public async Task Refresh_Token_Should_Return_Null()
    {
        var result = await _tokenService.RefreshTokenAsync();

        result.ShouldBeNull();
    }
}
