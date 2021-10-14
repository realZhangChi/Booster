using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IAuthorizationHandler
{
    Task<bool> AuthorizeAsync();
}
