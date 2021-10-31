namespace Booster.WeChat.Models.Identity;

public record Token
{
    public string AccessToken { get; init; } 

    public int ExpiresIn { get; init; }

    public long IssuedAt { get; init; }

    public string RefreshToken { get; init; }

    public string OpenId { get; init; }

    public string Scope { get; init; }

    public Token(
        string accessToken,
        int expiresIn,
        long issuedAt,
        string refreshToken,
        string openId,
        string scope)
    {
        AccessToken = accessToken;
        ExpiresIn = expiresIn;
        IssuedAt = issuedAt;
        RefreshToken = refreshToken;
        OpenId = openId;
        Scope = scope;
    }
}
