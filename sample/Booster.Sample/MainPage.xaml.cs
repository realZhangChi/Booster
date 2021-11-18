using Booster.Sample.ViewModels;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;

namespace Booster.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
