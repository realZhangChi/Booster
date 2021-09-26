using Maui.Toolkit.WeChat.Models.Identity;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface ITokenStore
{
    Task<Token?> GetOrNullAsync(string? key = null);

    Task SetAsync(Token token, string? key = null);
}
