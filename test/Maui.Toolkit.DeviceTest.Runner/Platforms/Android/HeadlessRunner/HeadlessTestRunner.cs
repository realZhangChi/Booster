using Android.App;
using Android.OS;
using Microsoft.DotNet.XHarness.TestRunners.Common;
using Microsoft.DotNet.XHarness.TestRunners.Xunit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.DeviceTest.Runner
{
    public class HeadlessTestRunner : AndroidApplicationEntryPoint
    {
        private readonly TestOptions _options;

        public override TextWriter Logger => null!;

        public override string TestsResultsFinalPath => Path.Combine(
                Application.Context.CacheDir!.AbsolutePath, DeviceTestRunnerConsts.TestResultsFileName);

        protected override int? MaxParallelThreads => System.Environment.ProcessorCount;

        protected override IDevice Device => new TestDevice();

        public HeadlessTestRunner(TestOptions options)
        {
            _options = options;
        }

        protected override IEnumerable<TestAssemblyInfo> GetTestAssemblies()
        {
            var assembly = _options.Assembly;
            var path = Path.Combine(Application.Context.CacheDir!.AbsolutePath, assembly?.GetName().Name + ".dll");
            if (!File.Exists(path))
                File.Create(path).Close();
            yield return new TestAssemblyInfo(assembly, path);
        }

        protected override void TerminateWithSuccess()
        {
        }

        internal async Task<Bundle> RunTestsAsync()
        {
            var bundle = new Bundle();

            TestsCompleted += OnTestsCompleted;

            await RunAsync();

            TestsCompleted -= OnTestsCompleted;

            if (File.Exists(TestsResultsFinalPath))
                bundle.PutString(DeviceTestRunnerConsts.TestResultsPathKey, TestsResultsFinalPath);

            if (bundle.GetLong(DeviceTestRunnerConsts.TestReturnCodeKey, -1) == -1)
                bundle.PutLong(DeviceTestRunnerConsts.TestReturnCodeKey, 1);

            return bundle;

            void OnTestsCompleted(object? sender, TestRunResult results)
            {
                var message =
                    $"Tests run: {results.ExecutedTests} " +
                    $"Passed: {results.PassedTests} " +
                    $"Inconclusive: {results.InconclusiveTests} " +
                    $"Failed: {results.FailedTests} " +
                    $"Ignored: {results.SkippedTests}";

                bundle.PutString(DeviceTestRunnerConsts.TestExcutionSummary, message);

                bundle.PutLong(DeviceTestRunnerConsts.TestReturnCodeKey, results.FailedTests == 0 ? 0 : 1);
            }
        }
    }
}
