namespace Maui.Toolkit.WeChat.Services.Identity;

public interface IUserInfoService
{
    Task<UserInfo?> GetUserInfoFromWeChatAsync(string appId, string? openId = null);
}
