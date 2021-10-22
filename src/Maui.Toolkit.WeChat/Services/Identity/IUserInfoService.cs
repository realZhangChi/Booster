using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IUserInfoService
{
    Task<UserInfo?> GetUserInfoFromWeChatAsync(string appId);
}
