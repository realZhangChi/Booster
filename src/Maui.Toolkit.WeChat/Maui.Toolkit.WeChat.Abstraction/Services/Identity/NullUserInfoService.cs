using Maui.Toolkit.WeChat.Models.Identity;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullUserInfoService : IUserInfoService
{
    public Task<UserInfo?> GetUserInfoFromWeChatAsync(string? openId = null)
    {
        return Task.FromResult((UserInfo?)null);
    }
}
