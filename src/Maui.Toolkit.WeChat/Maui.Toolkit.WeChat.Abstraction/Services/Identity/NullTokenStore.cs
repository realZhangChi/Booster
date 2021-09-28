namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullTokenStore : ITokenStore
{
    public Task<Token?> GetOrNullAsync(string? key = null)
    {
        return Task.FromResult((Token?)null);
    }

    public Task SetAsync(Token token, string? key = null)
    {
        return Task.CompletedTask;
    }
}
