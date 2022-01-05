using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Customs;
using Imi.Project.Mobile.ViewModels.Birds;
using Imi.Project.Mobile.ViewModels.Cages;
using Imi.Project.Mobile.ViewModels.Prescriptions;
using Imi.Project.Mobile.ViewModels.SpeciesGuide;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        private readonly IAuthApiService _authApiService;

        public LoginViewModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
            Email = "tine.franchois@gmail.com";
            Password = "Pa$$w0rd";
        }

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

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            var response = await _authApiService.Authenticate(Email, Password);
            if (response is object)
            {
                Message = response;
            }
            else
            {
                var mainPage = new CustomContainer();
                mainPage.FixedMode = true;
                mainPage.BarBackgroundColor = Color.White;
                mainPage.BarTextColor = Color.Black;
                mainPage.AddTab<HomeViewModel>("home", "home24.png");
                mainPage.AddTab<CagesViewModel>("cages", "cage24.png");
                mainPage.AddTab<BirdsViewModel>("birds", "bird24.png");
                mainPage.AddTab<PrescriptionsViewModel>("meds", "medication24.png");
                mainPage.AddTab<SpeciesViewModel>("guide", "guide24.png");
                Application.Current.MainPage = mainPage;
            }



        });
    }
}
