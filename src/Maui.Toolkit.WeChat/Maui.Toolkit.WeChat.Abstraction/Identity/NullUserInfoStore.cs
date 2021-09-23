namespace Maui.Toolkit.WeChat.Identity;

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
