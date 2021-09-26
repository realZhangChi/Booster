using Maui.Toolkit.WeChat.Models.Identity;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IUserInfoStore
{
    Task<UserInfo?> GetOrNullAsync(string? key = null);

    Task SetAsync(UserInfo userInfo, string? key = null);
}
