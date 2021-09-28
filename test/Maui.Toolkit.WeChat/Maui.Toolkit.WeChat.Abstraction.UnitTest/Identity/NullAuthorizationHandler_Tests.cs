namespace Maui.Toolkit.WeChat.Abstraction.UnitTest.Identity;

public class NullAuthorizationHandler_Tests
{
    private readonly IAuthorizationHandler _authorizationHandler;

    public NullAuthorizationHandler_Tests()
    {
        _authorizationHandler = new NullAuthorizationHandler();
    }

    [Fact]
    public async Task Authorize_Should_Return_False()
    {
        var result = await _authorizationHandler.AuthorizeAsync();

        result.ShouldBeFalse();
    }
}
