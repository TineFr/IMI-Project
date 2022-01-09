using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    class AccountViewModel : FreshBasePageModel
    {
        private readonly IAuthApiService _authApiService;

        public AccountViewModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }
        public ICommand LogoutCommand => new Command(() =>
        {
            _authApiService.LogOut();
            App.Current.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginViewModel>());

        });

    }
}
