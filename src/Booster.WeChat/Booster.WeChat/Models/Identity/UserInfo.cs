﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Booster.WeChat.Models.Identity;

// TODO: JsonPropertyNameAttribute should be remove
public record UserInfo
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
    Unknown = 0,
    Male = 1,
    Female = 2
}