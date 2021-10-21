using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface ITokenStore
{
    Task<Token?> GetOrNullAsync();

    Task SetAsync(Token token);
}
