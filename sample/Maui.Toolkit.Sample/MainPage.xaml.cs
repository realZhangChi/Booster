using Maui.Toolkit.WeChat.Services.Identity;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;

namespace Maui.Toolkit.Sample
{
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
            count++;
            CounterLabel.Text = $"Current count: {count}";

            SemanticScreenReader.Announce(CounterLabel.Text);
            await _authorizationService.AuthorizeAsync();
        }
    }
}
