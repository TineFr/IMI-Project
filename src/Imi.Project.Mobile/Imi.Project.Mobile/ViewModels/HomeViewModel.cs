using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class HomeViewModel : FreshBasePageModel
    {
        public ICommand OpenSettingsCommand => new Command(
             async () =>
             {
                 await CoreMethods.PushPageModel<SettingsViewModel>();
             });
        public ICommand OpenAccountCommand => new Command(
             async () =>
             {
                 await CoreMethods.PushPageModel<AccountViewModel>();
             });
    }
}
