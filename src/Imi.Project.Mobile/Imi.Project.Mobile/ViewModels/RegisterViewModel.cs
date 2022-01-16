using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Validators;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RegisterViewModel : FreshBasePageModel
    {
        private readonly IAuthApiService _authApiService;
        private readonly IValidator _registerModelValidator;

        public RegisterViewModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
            _registerModelValidator = new RegisterModelValidator();
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
            set
            {
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

        #region ValidationProperties

        private string nameMessage;

        public string NameMessage
        {
            get { return nameMessage; }
            set
            {
                nameMessage = value;
                RaisePropertyChanged(nameof(NameMessage));
            }
        }

        private string firstNameMessage;

        public string FirstNameMessage
        {
            get { return firstNameMessage; }
            set
            {
                firstNameMessage = value;
                RaisePropertyChanged(nameof(FirstNameMessage));
            }
        }

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

        private string dateOfBirthMessage;

        public string DateOfBirthMessage
        {
            get { return dateOfBirthMessage; }
            set
            {
                dateOfBirthMessage = value;
                RaisePropertyChanged(nameof(DateOfBirthMessage));
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
        private string confirmPasswordMessage;

        public string ConfirmPasswordMessage
        {
            get { return confirmPasswordMessage; }
            set
            {
                confirmPasswordMessage = value;
                RaisePropertyChanged(nameof(ConfirmPasswordMessage));
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

            var isValid = Validate(model);

            if (isValid)
            {
                var response = await _authApiService.Register(model);
                if (response is object)
                {
                    await CoreMethods.DisplayAlert("Error", response, "OK");

                }
                else
                {
                    await CoreMethods.DisplayAlert("Succes", "You were successfully registered", "OK");
                    await CoreMethods.PopPageModel(model); // goes back to login page to log in
                }
            }

        });

        public ICommand BackCommand => new Command(async () =>
        {
            await CoreMethods.PopPageModel();
        });


        private bool Validate(RegisterModel model)
        {
            ResetErrorMessages();
            var context = new ValidationContext<object>(model);
            var validationResult = _registerModelValidator.Validate(context);
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
                if (error.PropertyName == nameof(model.ConfirmPassword))
                {
                    ConfirmPasswordMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.Name))
                {
                    NameMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.FirstName))
                {
                    FirstNameMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.DateOfBirth))
                {
                    DateOfBirthMessage = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private void ResetErrorMessages()
        {
            EmailMessage = "";
            PasswordMessage = "";
            ConfirmPasswordMessage = "";
            NameMessage = "";
            FirstNameMessage = "";
            DateOfBirthMessage = "";
        }

    }
}
