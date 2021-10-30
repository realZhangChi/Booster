using Android.App;
using Android.Content.PM;

namespace Booster.Sample.Platforms.Android.WxApi;

[Activity(Name = "Booster.Sample.WeChatApi.WeChatEntryActivity", Exported = true, TaskAffinity = "Booster.Sample", LaunchMode = LaunchMode.SingleTask)]
public class WeChatEntryActivity : WeChat.Platforms.Android.WeChatApi.WeChatEntryActivity
{
}
