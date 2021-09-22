# Maui.Toolkit.WeChat

Maui.Toolkit.WeChat is a MAUI library that provides WeChat support for MAUI projects by calling the native SDK.

## Getting Started

1. Add Nuget

   TODO...

2. Register the necessary dependencies by calling the `UseWeChat` extension method in `MauiProgram`:

   ``` C#
   public static MauiApp CreateMauiApp()
   {
       var builder = MauiApp.CreateBuilder();
   
       builder
           .UseMauiApp<App>()
           .UseWeChat(new WeChatOption()
                      {
                          AppId = "",
                          AppSecret = ""
                      })
           .ConfigureFonts(fonts =>
                           {
                               fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                           });
   
   
       builder.Services.AddSingleton<MainPage>();
   
       return builder.Build();
   }
   ```

   

3. Inject `IAuthorizationService` service and call `AuthorizeAsync` method to call WeChat for authorization.

   MainPage.xaml.cs

   ``` C#
   public partial class MainPage : ContentPage
   {
       private readonly IAuthorizationService _authorizationService;
       int count = 0;
   
       public MainPage(IAuthorizationService authorizationService)
       {
           InitializeComponent();
           _authorizationService = authorizationService;
       }
   
       private async void OnCounterClicked(object sender, EventArgs e)
       {
           // count++;
           // CounterLabel.Text = $"Current count: {count}";
   
           // SemanticScreenReader.Announce(CounterLabel.Text);
           await _authorizationService.AuthorizeAsync();
       }
   }
   ```

   

