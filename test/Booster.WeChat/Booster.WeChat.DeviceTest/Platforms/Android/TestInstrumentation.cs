using Android.App;
using Android.Runtime;
using Booster.DeviceTest.Runner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.DeviceTest.Platforms.Android
{
    [Instrumentation(Name = "com.companyname.Booster.WeChat.DeviceTest.TestInstrumentation")]
    public class TestInstrumentation : MauiToolkitTestInstrumentation
    {
        public TestInstrumentation(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }
    }
}
