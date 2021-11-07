using Microsoft.CodeAnalysis;

namespace Booster.WeChat.SourceGenerator
{
    [Generator]
    public class WeChatActivityGenerator : ISourceGenerator
    {
        private const string WeChatActivityName = "WeChatActivity";

        public GeneratorExecutionContext Context { get; set; }

        public string TargetFramework { get; set; } = null!;

        public string RootNamespace { get; set; } = null!;

        public string ApplicationId { get; set; } = null!;

        public void Execute(GeneratorExecutionContext context)
        {
            if (!context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.TargetFramework", out var targetFramework))
                return;

            if (!targetFramework.Contains("-android", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            Context = context;
            TargetFramework = targetFramework;

            context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.ApplicationId", out var applicationId);
            ApplicationId = applicationId ?? throw new Exception("ApplicationId needs to be set.");

            context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.RootNamespace", out var rootNamespace);
            RootNamespace = rootNamespace ?? "BoosterNamespace";
            var code = Generate();
            context.AddSource(WeChatActivityName, code);
        }

        string Generate()
        {
            var imports = @"
using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Openapi;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
";
            var nameSpace = @"
namespace Booster.WeChat.Platforms.Android.WeChatApi;
";
            var attribute = $@"
[Activity(
    Name = ""{ApplicationId}.{WeChatActivityName}"",
    Exported = true,
    TaskAffinity = ""{ApplicationId}"",
    LaunchMode = LaunchMode.SingleTask)]
";
            var mainCode = @"
public class WeChatEntryActivity : MauiAppCompatActivity, IWXAPIEventHandler
{
    private readonly IWXAPI _wxApi;

    public WeChatEntryActivity()
    {
        _wxApi = MauiApplication.Current.Services.GetRequiredService<IWXAPI>();
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }

    protected override void OnNewIntent(Intent? intent)
    {
        base.OnNewIntent(intent);
        _wxApi.HandleIntent(intent, this);
    }

    public void OnReq(BaseReq? p0)
    {
        throw new NotImplementedException();
    }

    public async void OnResp(BaseResp? response)
    {
        if (response is null)
        {
            return;
        }

        if (response.Err_Code is BaseResp.ErrCode.ErrOk)
        {
            var handlerResolver = MauiApplication.Current.Services.GetRequiredService<IHandlerResolver>();
            var handler = await handlerResolver.ResolveAsync(response.Type);
            await handler.HandleAsync(response);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
";
            return imports + nameSpace + attribute + mainCode;

        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
