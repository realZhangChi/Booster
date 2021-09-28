namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullAuthorizationService : IAuthorizationService
{
    public Task<bool> AuthorizeAsync()
    {
        return Task.FromResult(false);
    }

    public Task AuthorizeCallbackAsync(string code)
    {
        return Task.CompletedTask;
    }
}
