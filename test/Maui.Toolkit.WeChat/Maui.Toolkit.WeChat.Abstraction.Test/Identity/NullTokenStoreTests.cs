using Maui.Toolkit.WeChat.Identity;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Abstraction.Test.Identity;

public class NullTokenStoreTests
{
    private readonly ITokenStore _tokenStore;

    public NullTokenStoreTests()
    {
        _tokenStore = new NullTokenStore();
    }

    [Fact]
    public async Task TokenShouldBeNull()
    {
        var token = await _tokenStore.GetOrNullAsync();

        token.ShouldBeNull();
    }

    [Fact]
    public async Task SetTest()
    {
        await _tokenStore.SetAsync(new Token());
    }
}
