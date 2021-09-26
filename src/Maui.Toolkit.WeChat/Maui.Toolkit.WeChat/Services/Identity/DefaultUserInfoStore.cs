using Maui.Toolkit.WeChat.Models.Identity;
using Microsoft.Maui.Essentials;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class DefaultUserInfoStore : IUserInfoStore
{
    private const string _keyPrefix = "Maui.Toolkit.WeChat.Identity.UserInfo:";

    public async Task<UserInfo?> GetOrNullAsync(string? key = null)
    {
        var token = await SecureStorage.GetAsync(_keyPrefix + key);
        if (string.IsNullOrWhiteSpace(token))
        {
            return null;
        }

        return JsonSerializer.Deserialize<UserInfo>(token);
    }

    public Task SetAsync(UserInfo userInfo, string? key = null)
    {
        return SecureStorage.SetAsync(_keyPrefix + key, JsonSerializer.Serialize(userInfo));
    }
}
