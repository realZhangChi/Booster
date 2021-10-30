using System;
using System.Text.Json;
using System.Threading.Tasks;

using Booster.WeChat.Models.Identity;

using Microsoft.Maui.Essentials;

namespace Booster.WeChat.Services.Identity;

public class DefaultTokenStore : ITokenStore
{
    private const string _key = "Booster.WeChat.Identity.Token";

    public async Task<Token?> GetOrNullAsync()
    {
        var token = await SecureStorage.GetAsync(_key);
        if (string.IsNullOrWhiteSpace(token))
        {
            return null;
        }

        return JsonSerializer.Deserialize<Token>(token);
    }

    public Task SetAsync(Token token)
    {
        if (token is null)
        {
            throw new ArgumentNullException(nameof(token));
        }

        return SecureStorage.SetAsync(_key, JsonSerializer.Serialize(token));
    }
}
