﻿using FluentValidation;
using FreshMvvm;
using Imi.Project.Common.Enums;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Birds
{
    public class AddBirdViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesService;
        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdService;
        private readonly IValidator _birdRequestModelValidator;
        public AddBirdViewModel(IBaseApiService<CageRequestModel, CageModel> cageService,
                                IBaseApiService<SpeciesModel, SpeciesModel> speciesService,
                                IBaseApiService<BirdRequestModel, BirdModel> birdService)
        {
            _cageService = cageService;
            _speciesService = speciesService;
            _birdService = birdService;
            _birdRequestModelValidator = new BirdRequestModelValidator();

        }


        #region properties

        private ObservableCollection<CageModel> cagesList;
        public ObservableCollection<CageModel> CagesList
        {
            get { return cagesList; }
            set
            {
                cagesList = value;
                RaisePropertyChanged(nameof(CagesList));
            }
        }

        private List<string> genders;
        public List<string> Genders
        {
            get { return genders; }
            set
            {
                genders = value;
                RaisePropertyChanged(nameof(Genders));
            }
        }

        private ObservableCollection<SpeciesModel> speciesList;
        public ObservableCollection<SpeciesModel> SpeciesList
        {
            get { return speciesList; }
            set
            {
                speciesList = value;
                RaisePropertyChanged(nameof(SpeciesList));
            }
        }
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
        private string food;
        public string Food
        {
            get { return food; }
            set
            {
                food = value;
                RaisePropertyChanged(nameof(Food));
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                RaisePropertyChanged(nameof(Gender));
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

        private CageModel cage;
        public CageModel Cage
        {
            get { return cage; }
            set
            {
                cage = value;
                RaisePropertyChanged(nameof(Cage));
            }
        }
        private SpeciesModel species;
        public SpeciesModel Species
        {
            get { return species; }
            set
            {
                species = value;
                RaisePropertyChanged(nameof(Species));
            }
        }
        private DateTime hatchDate;
        public DateTime HatchDate
        {
            get { return hatchDate; }
            set
            {
                hatchDate = value;
                RaisePropertyChanged(nameof(HatchDate));
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
        private string foodMessage;
        public string FoodMessage
        {
            get { return foodMessage; }
            set
            {
                foodMessage = value;
                RaisePropertyChanged(nameof(FoodMessage));
            }
        }

        private string genderMessage;
        public string GenderMessage
        {
            get { return genderMessage; }
            set
            {
                genderMessage = value;
                RaisePropertyChanged(nameof(GenderMessage));
            }
        }

        private string hatchDateMessage;
        public string HatchDateMessage
        {
            get { return hatchDateMessage; }
            set
            {
                hatchDateMessage = value;
                RaisePropertyChanged(nameof(HatchDateMessage));
            }
        }

        #endregion

        #region commands
        public ICommand SaveCommand => new Command(
             async () =>
             {
                 BirdRequestModel newBird = new BirdRequestModel
                 {
                     Name = this.Name,
                     HatchDate = this.HatchDate,
                     CageId = Cage?.Id,
                     SpeciesId = Species?.Id,
                     Food = this.Food,
                 //Image = "birds/budgie2.png"//later nog veranderen
             };
                 if (Gender != null) newBird.Gender = (Gender)Enum.Parse(typeof(Gender), Gender);

                 bool isValid = Validate(newBird);
                 if (isValid)
                 {
                     var response = await _birdService.AddAsync("birds", newBird);
                     if (response.ErrorMessage is object)
                     {
                         await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "Ok");
                     }
                     else await CoreMethods.PopPageModel();

                     await CoreMethods.PopPageModel();
                 }

                 else await CoreMethods.DisplayAlert("Hold!", "One or more inputs are not valid.\nCheck again.", "Ok");

             });

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });
        #endregion

        public async override void Init(object initData)
        {
            var species = await _speciesService.GetAllAsync("species");
            SpeciesList = new ObservableCollection<SpeciesModel>(species);
            var cages = await _cageService.GetAllAsync("me/cages");
            CagesList = new ObservableCollection<CageModel>(cages);

            Genders = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                                                    .Select(g => g.ToString())
                                                    .ToList();

            base.Init(initData);
        }



        private bool Validate(BirdRequestModel model)
        {
            ResetErrorMessages();
            var context = new ValidationContext<object>(model);
            var validationResult = _birdRequestModelValidator.Validate(context);
            foreach (var error in validationResult.Errors)
            {

                if (error.PropertyName == nameof(model.Name))
                {
                    NameMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.HatchDate))
                {
                    HatchDateMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.Gender))
                {
                    GenderMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.Food))
                {
                    FoodMessage = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private void ResetErrorMessages()
        {
            NameMessage = "";
            FoodMessage = "";
            HatchDateMessage = "";
            GenderMessage = "";
        }

    }
}