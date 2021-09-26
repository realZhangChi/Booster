using Maui.Toolkit.WeChat.Models.Identity;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullUserInfoStore : IUserInfoStore
{
    public Task<UserInfo?> GetOrNullAsync(string? key = null)
    {
        return Task.FromResult((UserInfo?)null);
    }

    public Task SetAsync(UserInfo userInfo, string? key = null)
    {
        return Task.CompletedTask;
    }
}
