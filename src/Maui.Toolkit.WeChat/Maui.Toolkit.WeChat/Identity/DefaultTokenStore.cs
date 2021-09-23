using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Maui.Toolkit.WeChat.Identity;

internal class DefaultTokenStore : ITokenStore
{
    private const string _keyPrefix = "Maui.Toolkit.WeChat.Identity.Token:";

    public async Task<Token?> GetOrNullAsync(string? key = null)
    {
        var token = await SecureStorage.GetAsync(_keyPrefix + key);
        if (string.IsNullOrWhiteSpace(token))
        {
            return null;
        }

        return JsonSerializer.Deserialize<Token>(token);
    }

    public Task SetAsync(Token token, string? key = null)
    {
        return SecureStorage.SetAsync(_keyPrefix + key, JsonSerializer.Serialize(token));
    }
}
