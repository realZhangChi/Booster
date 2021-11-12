using Booster.WeChat.ViewModels;

using Microsoft.Maui.Controls;

namespace Booster.WeChat.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
