using Android.App;
using Android.Content.PM;
using Microsoft.Maui.TestUtils.DeviceTests.Runners.HeadlessRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.DeviceTest
{
    [Activity(Name = "com.companyname.maui.toolkit.wechat.devicetest.TestActivity",
        Theme = "@style/Theme.MaterialComponents",
        ConfigurationChanges = 
        ConfigChanges.ScreenSize |
        ConfigChanges.Orientation |
        ConfigChanges.UiMode |
        ConfigChanges.ScreenLayout |
        ConfigChanges.SmallestScreenSize)]
    public class TestActivity : MauiTestActivity
    {
    }
}
