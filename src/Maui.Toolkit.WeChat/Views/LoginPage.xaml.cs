using Maui.Toolkit.WeChat.ViewModels;

using Microsoft.Maui.Controls;

namespace Maui.Toolkit.WeChat.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
