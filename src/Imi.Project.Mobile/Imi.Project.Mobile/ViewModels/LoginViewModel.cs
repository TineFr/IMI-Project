using FreshMvvm;
using Imi.Project.Mobile.Containers;
using Imi.Project.Mobile.Core.Interfaces;
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
                Application.Current.MainPage = MainContainer.Get();
            }
        });

        public ICommand ShowRegisterCommand => new Command(
                async () =>
                {
                    await CoreMethods.PushPageModel<RegisterViewModel>();
                });
    }
}
