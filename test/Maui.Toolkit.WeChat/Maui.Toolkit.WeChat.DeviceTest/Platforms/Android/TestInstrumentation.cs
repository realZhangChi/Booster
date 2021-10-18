using Android.App;
using Android.Runtime;
using Microsoft.Maui.TestUtils.DeviceTests.Runners.HeadlessRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.DeviceTest
{
    [Instrumentation(Name = "com.companyname.maui.toolkit.wechat.devicetest.TestInstrumentation")]
    public partial class TestInstrumentation : MauiTestInstrumentation
    {
        public TestInstrumentation(IntPtr handle, JniHandleOwnership ownership) : base(handle, ownership)
        {
        }
    }
}
