namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync();

    Task AuthorizedAsync(string code);
}
