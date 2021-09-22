# Maui.Toolkit

Maui.Toolkit is a toolkit that makes [MAUI](https://github.com/dotnet/maui) development easier. Maui.Toolkit creates binding libraries for commonly used third-party SDKs, and uses these binding libraries to develop MAUI libraries to provide out-of-the-box and **SOLID** development experience.

## Getting Started

Adding third-party SDK support to your application is a breeze, just add a few lines to your `MauiProgram` class:

``` C#
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    builder
        .UseMauiApp<App>()
        .UseWeChat(new WeChatOption()
        {
            AppId = "YOUR AppId",
            AppSecret = "YOUR AppSecret"
        })
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        });

    return builder.Build();
}
```

See the [/sample/Maui.Toolkit.Sample](https://github.com/realZhangChi/Maui.Toolkit/tree/main/sample/Maui.Toolkit.Sample) directory for a complete sample.

## Packages

| Package | Source | SDK Documentation |
|:-:|:-:|:-:|
| Maui.Toolkit.WeChat | [Maui.Toolkit.WeChat](https://github.com/realZhangChi/Maui.Toolkit/tree/main/src/Maui.Toolkit.WeChat) | [Documentation](https://developers.weixin.qq.com/doc/oplatform/Mobile_App/Resource_Center_Homepage.html)


## Support the Maui.Toolkit

Love Maui.Toolkit? **Please give a star** to this repository :star:
