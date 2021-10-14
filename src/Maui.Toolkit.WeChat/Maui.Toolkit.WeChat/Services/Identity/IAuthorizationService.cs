using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync();

    Task AuthorizeCallbackAsync(string appId, string appSecret, string code);
}
