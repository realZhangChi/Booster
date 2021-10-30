﻿using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UIKit;

namespace Booster.DeviceTest.Runner
{
    public class MauiTestViewController : UIViewController
	{
		Task? _task;

		public MauiTestViewController()
		{
		}

		public MauiTestViewController(Task task)
		{
			_task = task;
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

			if (_task is not null)
				await _task;

			var runner = MauiTestApplicationDelegate.Current.Services.GetRequiredService<HeadlessTestRunner>();

			await runner.RunTestsAsync();
		}
	}
}