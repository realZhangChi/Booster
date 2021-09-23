using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Maui.Toolkit.WeChat.Identity;

public class UserInfo
{
    [JsonPropertyName("openid")]
    public string? OpenId { get; set; }

    [JsonPropertyName("nickname")]
    public string? NickName { get; set; }

    [JsonPropertyName("sex")]
    public Sex Sex { get; set; }

    [JsonPropertyName("province")]
    public string? Province { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("headimgurl")]
    public string? HeadImgUrl { get; set; }

    [JsonPropertyName("privilege")]
    public List<string>? Privilege { get; set; }

    [JsonPropertyName("unionid")]
    public string? UnionId { get; set; }

    public UserInfo()
    {
        Privilege = new List<string>();
    }
}

public enum Sex
{
    Male = 1,
    Female = 2
}
