using Foundation;
using Booster.DeviceTest.Runner;
using Microsoft.Maui.Hosting;

namespace Booster.WeChat.DeviceTest
{
    [Register("HeadlessRunnerAppDelegate")]
    public class HeadlessRunnerAppDelegate : MauiTestApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
