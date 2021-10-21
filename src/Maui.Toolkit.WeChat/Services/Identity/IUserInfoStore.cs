using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IUserInfoStore
{
    Task<UserInfo?> GetOrNullAsync();

    Task SetAsync(UserInfo userInfo);
}
