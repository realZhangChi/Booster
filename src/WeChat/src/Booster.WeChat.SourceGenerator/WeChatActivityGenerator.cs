using Microsoft.CodeAnalysis;

namespace Booster.WeChat.SourceGenerator
{
    [Generator]
    public class WeChatActivityGenerator : ISourceGenerator
    {
        private const string WeChatActivityName = "WeChatActivity";
        private const string GeneratedCSharpFileExtension = ".sg.cs";

        public GeneratorExecutionContext Context { get; set; }

        public string TargetFramework { get; set; } = null!;

        public string RootNamespace { get; set; } = null!;

        public string ApplicationId { get; set; } = null!;

        public void Execute(GeneratorExecutionContext context)
        {
            if (!context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.TargetFramework", out var targetFramework))
                return;
            if (!targetFramework.Contains("android"))
                return;

            Context = context;
            TargetFramework = targetFramework;

            context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.ApplicationId", out var applicationId);
            ApplicationId = applicationId ?? throw new Exception("ApplicationId needs to be set.");

            context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.RootNamespace", out var rootNamespace);
            RootNamespace = rootNamespace ?? "Booster.WeChat";
            var code = Generate();
            context.AddSource(WeChatActivityName + GeneratedCSharpFileExtension, code);
        }

        string Generate()
        {
            var imports = @"
using System;

using Android.App;
using Android.Content;
using Android.Content.PM;

using Booster.WeChat.Platforms.Android.WeChatApi;

using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Openapi;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
";
            var nameSpace = $@"
namespace {RootNamespace};
";
            var attribute = $@"
[Activity(
    Name = ""{ApplicationId}.{WeChatActivityName}"",
    Exported = true,
    TaskAffinity = ""{ApplicationId}"",
    LaunchMode = LaunchMode.SingleTask)]
";
            var mainCode = @"
public class WeChatActivity : MauiAppCompatActivity, IWXAPIEventHandler
{
    private readonly IWXAPI _weChatApi;

    public WeChatActivity()
    {
        _weChatApi = MauiApplication.Current.Services.GetRequiredService<IWXAPI>();
    }

    protected override void OnNewIntent(Intent? intent)
    {
        base.OnNewIntent(intent);
        _weChatApi.HandleIntent(intent, this);
    }

    public void OnReq(BaseReq? p0)
    {
        throw new NotImplementedException();
    }

    public async void OnResp(BaseResp? response)
    {
        if (response is null)
                return;

        var responseProcessorResolver = MauiApplication.Current.Services.GetRequiredService<IResponseProcessorResolver>();
        var processor = await responseProcessorResolver.ResolveAsync(response.Type);

        await processor.ProcessResponseAsync(response);
    }
}
";
            return imports + nameSpace + attribute + mainCode;

        }

        public void Initialize(GeneratorInitializationContext context)
        {
//#if DEBUG
//            if (!System.Diagnostics.Debugger.IsAttached)
//                System.Diagnostics.Debugger.Launch();
//#endif
        }
    }
}
