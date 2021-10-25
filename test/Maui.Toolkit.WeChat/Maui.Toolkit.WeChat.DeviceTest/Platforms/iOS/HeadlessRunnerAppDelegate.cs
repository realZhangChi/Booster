using Foundation;
using Maui.Toolkit.DeviceTest.Runner;
using Microsoft.Maui.Hosting;

namespace Maui.Toolkit.WeChat.DeviceTest
{
    [Register("HeadlessRunnerAppDelegate")]
    public class HeadlessRunnerAppDelegate : MauiTestApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
