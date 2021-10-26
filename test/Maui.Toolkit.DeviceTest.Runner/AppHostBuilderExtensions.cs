using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace Maui.Toolkit.DeviceTest.Runner
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder UseHeadlessRunner(this MauiAppBuilder appHostBuilder, TestOptions options)
        {
            appHostBuilder.Services.AddSingleton(options);

#if __ANDROID__ || __IOS__
            appHostBuilder.Services.AddTransient(sp => new HeadlessTestRunner(sp.GetRequiredService<TestOptions>()));
#endif

            return appHostBuilder;
        }
    }
}