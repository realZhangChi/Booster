namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullAuthorizationHandler : IAuthorizationHandler
{
    public Task<bool> AuthorizeAsync()
    {
        return Task.FromResult(false);
    }
}
