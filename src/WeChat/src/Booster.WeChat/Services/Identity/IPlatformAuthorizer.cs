using System.Threading.Tasks;

namespace Booster.WeChat.Services.Identity;

public interface IPlatformAuthorizer
{
    Task<bool> AuthorizeAsync();
}
