using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Validators;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class AddCageViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;
        private readonly IValidator _cageRequestModelValidator;

        public AddCageViewModel(IBaseApiService<CageRequestModel, CageModel> cageService)
        {
            _cageService = cageService;
            _cageRequestModelValidator = new CageRequestModelValidator();
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

        private string imageMessage;

        public string ImageMessage
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged(nameof(ImageMessage));
            }
        }

        private string locationMessage;
        public string LocationMessage
        {
            get { return locationMessage; }
            set
            {
                locationMessage = value;
                RaisePropertyChanged(nameof(LocationMessage));
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

                 var isValid = Validate(newCage);

                 if (isValid)
                 {
                     var response = await _cageService.AddAsync("cages", newCage);
                     if (response.ErrorMessage is object)
                     {
                         await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "Ok");
                     }
                     else await CoreMethods.PopPageModel();

                 }

             });

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });
        #endregion



        private bool Validate(CageRequestModel model)
        {
            ResetErrorMessages();
            var context = new ValidationContext<object>(model);
            var validationResult = _cageRequestModelValidator.Validate(context);
            foreach (var error in validationResult.Errors)
            {

                if (error.PropertyName == nameof(model.Name))
                {

                    NameMessage = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(model.Location))
                {
                    LocationMessage = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private void ResetErrorMessages()
        {
            NameMessage = "";
            LocationMessage = "";
            ImageMessage = "";
        }
    }
}
