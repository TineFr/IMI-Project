using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RegisterViewModel : FreshBasePageModel
    {
        #region Properties
        private int name;

        public int Name
        {
            get { return name; }
            set { 
                name = value;
                RaisePropertyChanged(nameof(name));
            }     
        }

        private int firstName;

        public int FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged(nameof(firstName));
            }
        }

        private int email;

        public int Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(nameof(email));
            }
        }

        private int password;

        public int PassWord
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(password));
            }
        }
        private int confirmPassword;

        public int ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                RaisePropertyChanged(nameof(confirmPassword));
            }
        }

        #endregion
        public ICommand RegisterCommand => new Command(() =>
        {
            Application.Current.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        });

        public ICommand BackCommand => new Command(async () =>
        {
            await CoreMethods.PopPageModel();
        });


    }
}
