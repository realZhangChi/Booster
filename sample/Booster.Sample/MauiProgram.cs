using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Booster.Sample.ViewModels;
using Booster.WeChat.Extensions;

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
                    new WeChatWebOptions()
                    {
                        AppId = "AppId",
                        AppSecret = "AppSecret",
                        RedirectUrl = "RedirectUrl"
                    },
                    new WeChatMobileOptions()
                    {
                        AppId = "AppId",
                        AppSecret = "AppSecret",
                    })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();

            return builder.Build();
        }
    }
}