using System;

namespace Maui.Toolkit.WeChat;

public class WeChatOption
{
    public const string Name = "WeChat";

    public string AppId { get; set; }

    public string AppSecret { get; set; }

    public WeChatOption()
    {

    }

    public WeChatOption(
        string appId,
        string appSecret)
    {

        AppId = CheckAppId(appId);
        AppSecret = CheckAppSecret(appSecret);
    }

    private string CheckAppId(string appId)
    {
        if (string.IsNullOrWhiteSpace(appId))
        {
            throw new ArgumentNullException(nameof(appId));
        }

        return appId;
    }


    private string CheckAppSecret(string appSecret)
    {
        if (string.IsNullOrWhiteSpace(appSecret))
        {
            throw new ArgumentNullException(nameof(appSecret));
        }

        return appSecret;
    }
}
