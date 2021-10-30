using System.Threading.Tasks;

using Booster.WeChat.Models.Identity;

namespace Booster.WeChat.Services.Identity;

public interface IUserInfoStore
{
    Task<UserInfo?> GetOrNullAsync();

    Task SetAsync(UserInfo userInfo);
}
