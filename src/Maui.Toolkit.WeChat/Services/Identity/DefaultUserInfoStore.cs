using System;
using System.Text.Json;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Identity;

using Microsoft.Maui.Essentials;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class DefaultUserInfoStore : IUserInfoStore
{
    private const string _key = "Maui.Toolkit.WeChat.Identity.UserInfo";

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
