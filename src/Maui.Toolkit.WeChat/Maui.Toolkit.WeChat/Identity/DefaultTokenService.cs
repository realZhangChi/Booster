using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

internal class DefaultTokenService : ITokenService
{
    private const string _key = "Maui.Toolkit.WeChat.Identity:Token";

    public async Task<Token> GetOrNullAsync()
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
        return SecureStorage.SetAsync(_key, JsonSerializer.Serialize(token));
    }
}
