using System.Threading.Tasks;

namespace Booster.WeChat.Services.Identity;

public interface IAuthorizationHandler
{
    Task<bool> AuthorizeAsync();
}
