using System.Text.Json.Serialization;

namespace Booster.WeChat.Models.Identity;

// TODO: JsonPropertyNameAttribute Shoule Be Remove 
public record Token
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("issued_at")]
    public long IssuedAt { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = null!;

    [JsonPropertyName("openid")]
    public string OpenId { get; set; } = null!;

    [JsonPropertyName("scope")]
    public string Scope { get; set; } = null!;
}
