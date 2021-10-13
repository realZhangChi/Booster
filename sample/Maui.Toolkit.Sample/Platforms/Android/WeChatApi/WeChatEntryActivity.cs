using Android.App;
using Android.Content.PM;

namespace Maui.Toolkit.Sample.Platforms.Android.WxApi;

[Activity(Name = "Maui.Toolkit.Sample.WeChatApi.WeChatEntryActivity", Exported = true, TaskAffinity = "Maui.Toolkit.Sample", LaunchMode = LaunchMode.SingleTask)]
public class WeChatEntryActivity : WeChat.Platforms.Android.WeChatApi.WeChatEntryActivity
{
}
