using Booster.WeChat.Models.Share;

using WeChatText = Com.Tencent.MM.Opensdk.Modelmsg.WXTextObject;
using WeChatMessage = Com.Tencent.MM.Opensdk.Modelmsg.WXMediaMessage;

namespace Booster.WeChat.Platforms.Android.Share;

public static class MediaMessageExtensions
{
    public static WeChatMessage ToNative(this TextMessage textMessage)
    {
        var weChatText = new WeChatText()
        {
            Text = textMessage.Text
        };
        return new WeChatMessage()
        {
            Media_Object = weChatText,
            Description = textMessage.Description,
            Title = textMessage.Title
        };
    }
}
