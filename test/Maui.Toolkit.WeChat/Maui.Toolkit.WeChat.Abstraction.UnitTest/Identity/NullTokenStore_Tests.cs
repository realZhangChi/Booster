namespace Maui.Toolkit.WeChat.Abstraction.UnitTest.Identity;

public class NullTokenStore_Tests
{
    private readonly ITokenStore _tokenStore;

    public NullTokenStore_Tests()
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
