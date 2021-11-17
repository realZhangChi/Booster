using Booster.WeChat.Models.Identity;
using Booster.WeChat.Services.Identity;

using Microsoft.Maui.Controls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Booster.Sample.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserInfoStore _userInfoStore;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _name = null!;
        protected string Name
        {
            get => _name;
            private set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(
            IAuthorizationService authorizationService,
            IUserInfoStore userInfoStore)
        {
            _authorizationService = authorizationService;
            _userInfoStore = userInfoStore;

            MessagingCenter.Subscribe<IAuthorizationService, AuthorizationMessageArgs>(
                this,
                AuthorizationMessages.Success,
                async (sender, args) =>
                {
                    await GetUserInfoAsync();
                });
        }

        public ICommand LoginCommand => new Command(() => Login());

        private Task Login()
        {
            return _authorizationService.AuthorizeAsync();
        }

        private async Task GetUserInfoAsync()
        {
            var userInfo = await _userInfoStore.GetOrNullAsync();
            if (userInfo is not null)
            {
                _name = userInfo.NickName!;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<IAuthorizationService, AuthorizationMessageArgs>(
                this,
                AuthorizationMessages.Success);
        }
    }
}
