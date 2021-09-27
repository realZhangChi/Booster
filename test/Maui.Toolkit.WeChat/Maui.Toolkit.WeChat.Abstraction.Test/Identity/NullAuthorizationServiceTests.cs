using Maui.Toolkit.WeChat.Services.Identity;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Abstraction.Test.Identity;

public class NullAuthorizationServiceTests
{
    private readonly IAuthorizationService _authorizationService;

    public NullAuthorizationServiceTests()
    {
        _authorizationService = new NullAuthorizationService();
    }

    [Fact]
    public async Task AuthorizeShouldReturnFalse()
    {
        var result = await _authorizationService.AuthorizeAsync();

        result.ShouldBeFalse();
    }

    [Fact]
    public async Task AuthorizedTest()
    {
        await _authorizationService.AuthorizedAsync(string.Empty);
    }
}
