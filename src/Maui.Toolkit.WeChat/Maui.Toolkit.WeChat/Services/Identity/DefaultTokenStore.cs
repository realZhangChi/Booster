using Microsoft.Maui.Essentials;
using System.Threading.Tasks;
using System.Text.Json;
using Maui.Toolkit.WeChat.Models.Identity;

namespace Maui.Toolkit.WeChat.Services.Identity;

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
