using Maui.Toolkit.DeviceTest.Runner;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace Maui.Toolkit.WeChat.DeviceTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseHeadlessRunner(new TestOptions()
                {
                    Assembly = typeof(MauiProgram).Assembly
                });

            return builder.Build();
        }
    }
}