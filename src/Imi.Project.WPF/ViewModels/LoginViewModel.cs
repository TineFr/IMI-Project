using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Imi.Project.WPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            { 
                email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {
            Email = "tine.franchois@gmail.com";
            Password = "Pa$$w0rd";
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
