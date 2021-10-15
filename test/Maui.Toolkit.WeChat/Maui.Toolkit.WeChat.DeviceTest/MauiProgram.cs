using Maui.Toolkit.DeviceTest;

using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Essentials;

namespace Maui.Toolkit.WeChat.DeviceTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .ConfigureLifecycleEvents(life =>
                {
#if __ANDROID__
					life.AddAndroid(android =>
					{
						android.OnCreate((activity, bundle) =>
							Platform.Init(activity, bundle));
						android.OnRequestPermissionsResult((activity, requestCode, permissions, grantResults) =>
							Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults));
					});
#endif
                })
                .ConfigureTests(new TestOptions()
                {
                    Assemblies = {
                        typeof(MauiProgram).Assembly
                    }
                })
                .UseHeadlessRunner(new HeadlessRunnerOptions());

            return builder.Build();
        }
    }
}