using Maui.Toolkit.WeChat.Identity;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Abstraction.Test.Identity;

public class NullAuthorizationHandlerTests
{
    private readonly IAuthorizationHandler _authorizationHandler;

    public NullAuthorizationHandlerTests()
    {
        _authorizationHandler = new NullAuthorizationHandler();
    }

    [Fact]
    public async Task AuthorizeShouldReturnFalse()
    {
        var result = await _authorizationHandler.AuthorizeAsync();

        result.ShouldBeFalse();
    }
}
