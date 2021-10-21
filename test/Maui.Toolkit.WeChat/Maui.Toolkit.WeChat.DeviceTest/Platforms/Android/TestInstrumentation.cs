using Android.App;
using Android.Runtime;
using Maui.Toolkit.DeviceTest.Runner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.DeviceTest.Platforms.Android
{
    [Instrumentation(Name = "com.companyname.Maui.Toolkit.WeChat.DeviceTest.TestInstrumentation")]
    public class TestInstrumentation : MauiToolkitTestInstrumentation
    {
        public TestInstrumentation(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }
    }
}
