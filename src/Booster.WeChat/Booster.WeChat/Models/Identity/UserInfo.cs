using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Booster.WeChat.Models.Identity;

// TODO: JsonPropertyNameAttribute should be remove
public record UserInfo
{
    [JsonPropertyName("openid")]
    public string? OpenId { get; init; }

    [JsonPropertyName("nickname")]
    public string? NickName { get; init; }

    [JsonPropertyName("sex")]
    public Sex Sex { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }

    [JsonPropertyName("province")]
    public string? Province { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("headimgurl")]
    public string? HeadImgUrl { get; init; }

    [JsonPropertyName("privilege")]
    public List<string>? Privilege { get; init; }

    [JsonPropertyName("unionid")]
    public string? UnionId { get; init; }

    public UserInfo(
        string openId,
        string nickName,
        Sex sex,
        string country,
        string province,
        string city,
        string headImgUrl,
        List<string> privilege,
        string unionId)
    {
        OpenId = openId;
        NickName = nickName;
        Sex = sex;
        Country = country;
        Province = province;
        City = city;
        HeadImgUrl = headImgUrl;
        Privilege = privilege;
        UnionId = unionId;
    }
}

public enum Sex
{
    Unknown = 0,
    Male = 1,
    Female = 2
}
