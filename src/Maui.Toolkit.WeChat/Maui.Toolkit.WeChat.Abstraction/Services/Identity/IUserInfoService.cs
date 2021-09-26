using Maui.Toolkit.WeChat.Models.Identity;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IUserInfoService
{
    Task<UserInfo?> GetUserInfoFromWeChatAsync(string? openId = null);
}
