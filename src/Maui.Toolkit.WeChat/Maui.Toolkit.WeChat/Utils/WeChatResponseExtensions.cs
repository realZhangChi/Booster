using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Maui.Toolkit.WeChat.Utils;

internal static class WeChatResponseExtensions
{
    internal static async Task<T?> EnsureSuccessAndDeserializeAsync<T>(this HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        using var jsonDoc = JsonDocument.Parse(content);

        var hasErrorCode = jsonDoc.RootElement.TryGetProperty("errcode", out var errorCodeElement);
        if (hasErrorCode)
        {
            var errorCode = errorCodeElement.GetInt32();
            if (errorCode != 0)
            {
                throw new NotImplementedException(jsonDoc.RootElement.ToString());
            }
        }

        return JsonSerializer.Deserialize<T>(jsonDoc);
    }
}
