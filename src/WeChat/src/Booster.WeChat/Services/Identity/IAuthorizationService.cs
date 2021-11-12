using System.Threading.Tasks;

namespace Booster.WeChat.Services.Identity;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync();

    Task AuthorizeCallbackAsync(string appId, string appSecret, string code);
}
