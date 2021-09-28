using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat;

public class WeChatOption
{
    public const string Name = "WeChat";

    public string AppId { get; set; }

    public string AppSecret { get; set; }

    public WeChatOption(
        string appId,
        string appSecret)
    {
        AppId = appId;
        AppSecret = appSecret;
    }
}
