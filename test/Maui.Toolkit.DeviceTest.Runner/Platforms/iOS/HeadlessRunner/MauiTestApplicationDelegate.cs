﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using Microsoft.DotNet.XHarness.iOS.Shared.Execution;
using Microsoft.DotNet.XHarness.TestRunners.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;
using UIKit;

namespace Maui.Toolkit.DeviceTest.Runner
{
	public abstract class MauiTestApplicationDelegate : UIApplicationDelegate
	{
		// TODO: https://github.com/xamarin/xamarin-macios/issues/12555
		readonly static string[] EnvVarNames = {
			"NUNIT_AUTOSTART",
			"NUNIT_AUTOEXIT",
			"NUNIT_ENABLE_NETWORK",
			"DISABLE_SYSTEM_PERMISSION_TESTS",
			"NUNIT_HOSTNAME",
			"NUNIT_TRANSPORT",
			"NUNIT_LOG_FILE",
			"NUNIT_HOSTPORT",
			"USE_TCP_TUNNEL",
			"RUN_END_TAG",
			"NUNIT_ENABLE_XML_OUTPUT",
			"NUNIT_ENABLE_XML_MODE",
			"NUNIT_XML_VERSION",
			"NUNIT_SORTNAMES",
			"NUNIT_RUN_ALL",
			"NUNIT_SKIPPED_METHODS",
			"NUNIT_SKIPPED_CLASSES",
		};

		readonly static Dictionary<string, string?> EnvVars = new();

		static MauiTestApplicationDelegate()
		{
			// copy into dictionary for later
			foreach (var envvar in EnvVarNames)
			{
				EnvVars[envvar] = Environment.GetEnvironmentVariable(envvar);
				Console.WriteLine($"{envvar}:{EnvVars[envvar]}");
			}
		}

		static void SetEnvironmentVariables()
		{
			// read from dictionary
			foreach (var envvar in EnvVars)
			{
				Console.WriteLine($"  {envvar.Key} = '{envvar.Value}'");
				Environment.SetEnvironmentVariable(envvar.Key, envvar.Value);
			}
		}

		public static bool IsHeadlessRunner(string[] args)
		{
			// usually means this is from xharness
			return args?.Length > 0 || Environment.GetEnvironmentVariable("NUNIT_AUTOEXIT")?.Length > 0;
		}

		protected MauiTestApplicationDelegate()
		{
			Current = this;
		}

		public static MauiTestApplicationDelegate Current { get; private set; } = null!;

		public IServiceProvider Services { get; private set; } = null!;

		public TestOptions Options { get; private set; } = null!;

		public override UIWindow? Window { get; set; }

		protected abstract MauiApp CreateMauiApp();

		public override bool WillFinishLaunching(UIApplication application, NSDictionary launchOptions)
		{
			var mauiApp = CreateMauiApp();
			Services = mauiApp.Services;

			SetEnvironmentVariables();

			Options = Services.GetRequiredService<TestOptions>();

			return true;
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			var tcs = new TaskCompletionSource();

			Window = new UIWindow(UIScreen.MainScreen.Bounds)
			{
				RootViewController = new MauiTestViewController(tcs.Task)
			};

			Window.MakeKeyAndVisible();

			tcs.TrySetResult();

			return true;
		}

	}
}
