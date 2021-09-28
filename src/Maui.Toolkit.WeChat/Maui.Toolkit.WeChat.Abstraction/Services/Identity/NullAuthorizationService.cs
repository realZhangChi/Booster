namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullAuthorizationService : IAuthorizationService
{
    public Task<bool> AuthorizeAsync()
    {
        return Task.FromResult(false);
    }

    public Task AuthorizedAsync(string code)
    {
        return Task.CompletedTask;
    }
}
