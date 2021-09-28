namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync();

    Task AuthorizeCallbackAsync(string code);
}
