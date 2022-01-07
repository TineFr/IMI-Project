﻿using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System;
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
            //IsVisible = new Dictionary<string, bool>
            //{
            //     {"Name", false},

            //}
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

        //#region ValidationProperties





        //private string nameMessage;

        //public string NameMessage
        //{
        //    get { return nameMessage; }
        //    set
        //    {
        //        nameMessage = value;
        //        RaisePropertyChanged(nameof(NameMessage));
        //    }
        //}

        //private string firstNameMessage;

        //public string FirstNameMessage
        //{
        //    get { return firstNameMessage; }
        //    set
        //    {
        //        firstNameMessage = value;
        //        RaisePropertyChanged(nameof(FirstNameMessage));
        //    }
        //}

        //private string emailMessage;

        //public string EmailMessage
        //{
        //    get { return emailMessage; }
        //    set
        //    {
        //        emailMessage = value;
        //        RaisePropertyChanged(nameof(EmailMessage));
        //    }
        //}

        //private string dateOfBirthMessage;

        //public string DateOfBirthMessage
        //{
        //    get { return dateOfBirthMessage; }
        //    set
        //    {
        //        dateOfBirthMessage = value;
        //        RaisePropertyChanged(nameof(DateOfBirthMessage));
        //    }
        //}
        //private string passwordMessage;

        //public string PasswordMessage
        //{
        //    get { return passwordMessage; }
        //    set
        //    {
        //        passwordMessage = value;
        //        RaisePropertyChanged(nameof(PasswordMessage));
        //    }
        //}
        //private string confirmPassword;

        //public string ConfirmPassword
        //{
        //    get { return confirmPassword; }
        //    set
        //    {
        //        confirmPassword = value;
        //        RaisePropertyChanged(nameof(confirmPassword));
        //    }
        //}


        //#endregion
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
                await CoreMethods.DisplayAlert("Error", response, "OK");

            }
            else
            {
                /*      var loginResponse = await _authApiService.Authenticate(model.Email, model.Password);*/  // automatically login after registering
                                                                                                                //if (loginResponse is object)
                                                                                                                //{
                                                                                                                //    await CoreMethods.PopPageModel(); // goes back to login page to try again
                                                                                                                //}
                                                                                                                //else
                                                                                                                //{
                                                                                                                //    Application.Current.MainPage = MainContainer.Get();
                                                                                                                //}
            }
        });

        public ICommand BackCommand => new Command(async () =>
        {
            await CoreMethods.PopPageModel();
        });


    }
}
