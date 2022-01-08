using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Containers;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Validators;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        private readonly IAuthApiService _authApiService;
        private IValidator _loginModelValidator;

        public LoginViewModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;

            Email = "tine.franchois@gmail.com";     // hardcoded for ease
            Password = "Pa$$w0rd";
            _loginModelValidator = new LoginModelValidator();
        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        public override void ReverseInit(object returnedData)
        {
            var model = returnedData as RegisterModel;
            Email = model.Email;
            Password = model.Password;
            base.ReverseInit(returnedData);
        }


        #region Properties
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


        #endregion

        #region ValidationProperties

        private string emailMessage;

        public string EmailMessage
        {
            get { return emailMessage; }
            set
            {
                emailMessage = value;
                RaisePropertyChanged(nameof(EmailMessage));
            }
        }

        private string passwordMessage;

        public string PasswordMessage
        {
            get { return passwordMessage; }
            set
            {
                passwordMessage = value;
                RaisePropertyChanged(nameof(PasswordMessage));
            }
        }

        private string failedMessage;

        public string FailedMessage
        {
            get { return failedMessage; }
            set
            {
                failedMessage = value;
                RaisePropertyChanged(nameof(FailedMessage));
            }
        }

        #endregion




        public ICommand LoginCommand => new Command(async () =>
        {
            if (!string.IsNullOrEmpty(FailedMessage)) FailedMessage = "";
            LoginRequestModel model = new LoginRequestModel
            {
                Email = Email,
                Password = Password,
            };
            var isValid = Validate(model);
            if (isValid)
            {
                var response = await _authApiService.Authenticate(model);
                if (response is object)
                {
                    FailedMessage = response;
                }
                else
                {
                    Application.Current.MainPage = MainContainer.Get();
                }
            }

        });

        public ICommand ShowRegisterCommand => new Command(
                async () =>
                {
                    await CoreMethods.PushPageModel<RegisterViewModel>();
                });

        private bool Validate(LoginRequestModel model)
        {
            ResetErrorMessages();
            var context = new ValidationContext<object>(model);
            var validationResult = _loginModelValidator.Validate(context);
            foreach (var error in validationResult.Errors)
            {

                if (error.PropertyName == nameof(model.Email))
                {

                    EmailMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.Password))
                {
                    PasswordMessage = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private void ResetErrorMessages()
        {
            EmailMessage = "";
            PasswordMessage = "";
        }
    }
}
