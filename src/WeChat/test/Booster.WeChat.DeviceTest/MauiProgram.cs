using Booster.DeviceTest.Runner;
using Booster.WeChat.Extensions;

using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace Booster.WeChat.DeviceTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseWeChat(
                    new WeChatWebOptions
                    {
                        AppId = "test",
                        AppSecret = "test",
                        RedirectUrl = "WeChatRedirect"
                    },
                    new WeChatMobileOptions()
                    {
                        AppId = "test",
                        AppSecret = "test"
                    })
                .UseHeadlessRunner(new TestOptions()
                {
                    Assembly = typeof(MauiProgram).Assembly
                });

            return builder.Build();
        }
    }
}