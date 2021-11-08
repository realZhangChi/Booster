using System;
using System.Text.Json;
using System.Threading.Tasks;

using Booster.WeChat.Models.Identity;

using Microsoft.Maui.Essentials;

namespace Booster.WeChat.Services.Identity;

public class DefaultUserInfoStore : IUserInfoStore
{
    private const string _key = "Booster.WeChat.Identity.UserInfo";

    public async Task<UserInfo?> GetOrNullAsync()
    {
        var token = await SecureStorage.GetAsync(_key);
        if (string.IsNullOrWhiteSpace(token))
        {
            return null;
        }

        return JsonSerializer.Deserialize<UserInfo>(token);
    }

    public Task SetAsync(UserInfo userInfo)
    {
        if (userInfo is null)
        {
            throw new ArgumentNullException(nameof(userInfo));
        }

        return SecureStorage.SetAsync(_key, JsonSerializer.Serialize(userInfo));
    }
}
