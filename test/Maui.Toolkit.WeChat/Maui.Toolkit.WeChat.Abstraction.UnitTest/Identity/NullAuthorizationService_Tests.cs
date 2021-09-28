namespace Maui.Toolkit.WeChat.Abstraction.UnitTest.Identity;

public class NullAuthorizationService_Tests
{
    private readonly IAuthorizationService _authorizationService;

    public NullAuthorizationService_Tests()
    {
        _authorizationService = new NullAuthorizationService();
    }

    [Fact]
    public async Task Authorize_Should_Return_False()
    {
        var result = await _authorizationService.AuthorizeAsync();

        result.ShouldBeFalse();
    }

    [Fact]
    public async Task AuthorizeCallback_Test()
    {
        await _authorizationService.AuthorizeCallbackAsync(string.Empty);
    }
}
