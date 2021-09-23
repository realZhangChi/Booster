using System.Text.Json.Serialization;

namespace Maui.Toolkit.WeChat.Identity;

public class Token
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonIgnore]
    public long IssuedAt { get; set; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    [JsonPropertyName("openid")]
    public string? OpenId { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}
