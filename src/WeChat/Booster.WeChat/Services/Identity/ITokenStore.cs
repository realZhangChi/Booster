using System.Threading.Tasks;

using Booster.WeChat.Models.Identity;

namespace Booster.WeChat.Services.Identity;

public interface ITokenStore
{
    Task<Token?> GetOrNullAsync();

    Task SetAsync(Token token);
}
