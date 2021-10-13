using System;

namespace Maui.Toolkit.WeChat;

public class WeChatWebOption : WeChatOption
{
    public string RedirectUrl { get; set; }

    public WeChatWebOption()
    {

    }

    public WeChatWebOption(string appId, string appSecret, string redirectUrl) : base(appId, appSecret)
    {
        RedirectUrl = CheckRedirectUrl(redirectUrl);
    }

    private string CheckRedirectUrl(string redirectUrl)
    {
        if (string.IsNullOrWhiteSpace(redirectUrl))
        {
            throw new ArgumentNullException(nameof(redirectUrl));
        }

        return redirectUrl;
    }
}
