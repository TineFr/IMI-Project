﻿using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class AddCageViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;

        public AddCageViewModel(IBaseApiService<CageRequestModel, CageModel> cageService)
        {
            _cageService = cageService;
        }

        #region properties

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged(nameof(Image));
            }
        }

        private string location;
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }

        #endregion

        #region commands

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 CageRequestModel newCage = new CageRequestModel
                 {
                     Name = this.Name,
                     Location = this.Location,
                     //Image = "cage1.png" //later aan te passen
                 };
                 var response = await _cageService.AddAsync("cages", newCage);  
                 if (response.ErrorMessage is object)
                 {
                     await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "Ok");
                 }
                 else await CoreMethods.PopPageModel();
             });

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });
        #endregion
    }
}
