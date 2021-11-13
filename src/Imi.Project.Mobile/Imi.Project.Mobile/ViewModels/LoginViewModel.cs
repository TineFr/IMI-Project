using FreshMvvm;
using Imi.Project.Mobile.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {

        public ICommand LoginCommand => new Command(() =>
        {
            Application.Current.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        });

        public ICommand ShowRegisterCommand => new Command( async () =>
        {
            await CoreMethods.PushPageModel<RegisterViewModel>();
        });
    }
}
