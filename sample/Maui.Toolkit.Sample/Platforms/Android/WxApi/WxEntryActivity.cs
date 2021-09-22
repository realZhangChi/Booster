using Android.App;
using Android.Content.PM;

namespace Maui.Toolkit.Sample.Platforms.Android.WxApi;

[Activity(Name = "Maui.Toolkit.Sample.WxApi.WxEntryActivity", Exported = true, TaskAffinity = "Maui.Toolkit.Sample", LaunchMode = LaunchMode.SingleTask)]
public class WxEntryActivity : WeChat.Platforms.Android.WxApi.WxEntryActivity
{
}
