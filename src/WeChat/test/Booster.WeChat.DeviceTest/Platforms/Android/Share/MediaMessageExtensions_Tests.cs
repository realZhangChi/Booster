using Com.Tencent.MM.Opensdk.Modelmsg;
using Booster.WeChat.Models.Share;
using Booster.WeChat.Platforms.Android.Share;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.Share
{
    public class MediaMessageExtensions_Tests
    {
        [Fact]
        public void Should_Get_Native_TextMessage()
        {
            var title = "Title";
            var description = "Description";
            var text = "Text";
            var textMessage = new TextMessage(title, description, text);

            var nativeMessage = textMessage.ToNative();

            nativeMessage.Media_Object.ShouldBeAssignableTo(typeof(WXTextObject));
            ((WXTextObject)nativeMessage.Media_Object).Text.ShouldBe(text);
            nativeMessage.Title.ShouldBe(title);
            nativeMessage.Description.ShouldBe(description);
        }
    }
}
