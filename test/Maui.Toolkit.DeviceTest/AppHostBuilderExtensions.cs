using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace Maui.Toolkit.DeviceTest;

public static class AppHostBuilderExtensions
{
	public static MauiAppBuilder ConfigureTests(this MauiAppBuilder appHostBuilder, TestOptions options)
	{
		appHostBuilder.Services.AddSingleton(options);

		return appHostBuilder;
	}

	public static MauiAppBuilder UseHeadlessRunner(this MauiAppBuilder appHostBuilder, HeadlessRunnerOptions options)
    {
        appHostBuilder.Services.AddSingleton(options);

#if __ANDROID__
			appHostBuilder.Services.AddTransient(svc => new Maui.Toolkit.DeviceTest.HeadlessRunner.HeadlessTestRunner(
					svc.GetRequiredService<HeadlessRunnerOptions>(),
					svc.GetRequiredService<TestOptions>()));
#endif

		return appHostBuilder;
    }
}
