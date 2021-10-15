using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.DeviceTest;

public class HeadlessRunnerOptions
{
	public string TestResultsFilename { get; set; } = "TestResults.xml";
	public bool RequiresUIContext { get; set; } = true;
}
