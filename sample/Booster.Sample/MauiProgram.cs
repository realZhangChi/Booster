using Booster.WeChat;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Booster.WeChat.Extensions;
using Microsoft.Extensions.Options;

namespace Booster.Sample
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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}