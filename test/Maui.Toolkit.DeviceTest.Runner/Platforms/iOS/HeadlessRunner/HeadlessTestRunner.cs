using Microsoft.DotNet.XHarness.TestRunners.Common;
using Microsoft.DotNet.XHarness.TestRunners.Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace Maui.Toolkit.DeviceTest.Runner
{
    class HeadlessTestRunner : iOSApplicationEntryPoint
    {
        readonly TestOptions _options;

        public HeadlessTestRunner(TestOptions options)
        {
            _options = options;
        }

        protected override bool LogExcludedTests => true;

        protected override int? MaxParallelThreads => Environment.ProcessorCount;

        protected override IDevice Device { get; } = new TestDevice();

        protected override IEnumerable<TestAssemblyInfo> GetTestAssemblies()
        {
            yield return new TestAssemblyInfo(_options.Assembly, _options.Assembly.Location);
        }

        protected override void TerminateWithSuccess()
        {
            var s = new ObjCRuntime.Selector("terminateWithSuccess");
            UIApplication.SharedApplication.PerformSelector(s, UIApplication.SharedApplication, 0);
        }

        public async Task RunTestsAsync()
        {
            TestsCompleted += OnTestsCompleted;

            await RunAsync();

            TestsCompleted -= OnTestsCompleted;

            void OnTestsCompleted(object? sender, TestRunResult results)
            {
                var message =
                    $"Tests run: {results.ExecutedTests} " +
                    $"Passed: {results.PassedTests} " +
                    $"Inconclusive: {results.InconclusiveTests} " +
                    $"Failed: {results.FailedTests} " +
                    $"Ignored: {results.SkippedTests}";

                Console.WriteLine(message);
            }
        }
    }
}
