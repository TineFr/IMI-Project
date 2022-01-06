using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models.Api.Authentication;
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
    public class RegisterViewModel : FreshBasePageModel
    {
        private readonly IAuthApiService _authApiService;

        public RegisterViewModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            DateOfBirth = DateTime.Today;
        }
        #region Properties
        private string name;

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                RaisePropertyChanged(nameof(name));
            }     
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged(nameof(firstName));
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(nameof(email));
            }
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                RaisePropertyChanged(nameof(DateOfBirth));
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(password));
            }
        }
        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                RaisePropertyChanged(nameof(confirmPassword));
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

        #endregion
        public ICommand RegisterCommand => new Command(async () =>
        {
            RegisterModel model = new RegisterModel
            {
                Name = name,
                FirstName = firstName,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                DateOfBirth = DateOfBirth
            };

            var response = await _authApiService.Register(model);
            if (response is object)
            {
                Message = response;
            }
            else
            {
                var loginResponse = await _authApiService.Authenticate(model.Email, model.Password);  // automatically login after registering
                if (loginResponse is object)
                {
                    await CoreMethods.PopPageModel(); // goes back to login page to try again
                }
                else
                {
                    var mainPage = new CustomContainer
                    {
                        BarBackgroundColor = Color.White,
                        BarTextColor = Color.Black
                    };
                    mainPage.AddTab<HomeViewModel>("home", "home24.png");
                    mainPage.AddTab<CagesViewModel>("cages", "cage24.png");
                    mainPage.AddTab<BirdsViewModel>("birds", "bird24.png");
                    mainPage.AddTab<PrescriptionsViewModel>("meds", "medication24.png");
                    mainPage.AddTab<SpeciesViewModel>("guide", "guide24.png");
                    Application.Current.MainPage = mainPage;
                }
            }

            //Application.Current.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        });

        public ICommand BackCommand => new Command(async () =>
        {
            await CoreMethods.PopPageModel();
        });


    }
}
