using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface ITokenStore
{
    Task<Token?> GetOrNullAsync(string? key = null);

    Task SetAsync(Token token, string? key = null);
}
