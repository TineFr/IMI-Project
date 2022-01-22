using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Core;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Validators;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class EditCageViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;
        private readonly IValidator<CageRequestModel> _cageRequestModelValidator;

        public EditCageViewModel(IBaseApiService<CageRequestModel, CageModel> cageService,
                                IValidator<CageRequestModel> validator)
        {
            _cageService = cageService;
            _cageRequestModelValidator = validator;
        }

        private CageModel cageToEdit;

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

        private Stream image;

        public Stream Image
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
        public override void Init(object initData)
        {
            cageToEdit = initData as CageModel;
            Name = cageToEdit.Name;
            Location = cageToEdit.Location;
            base.Init(initData);
        }

        #region commands
        public ICommand DeleteCommand => new Command(
             async () =>
             {
                 var action = await CoreMethods.DisplayAlert("Do you wish to delete this cage?", null, "YES", "NO");
                 if (action)
                 {
                     var response = await _cageService.DeleteAsync($"cages/{cageToEdit.Id}");
                     if (response is object)
                     {
                         await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "OK");
                     }
                     else await CoreMethods.PopToRoot(true);
                 }
             });

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 CageRequestModel model = new CageRequestModel
                 {
                     Name = Name,
                     Location = Location,
                 };
                 if (Image != null) model.ImageInfo = new ImageInfo { FileName = "name.png", Image = this.Image };
                 var isValid = Validate(model);
                 if (isValid)
                 {
                     var response = await _cageService.UpdateAsync($"cages/{cageToEdit.Id}", model);
                     if (response.ErrorMessage is object)
                     {
                         await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "OK");
                     }
                     else await CoreMethods.PopPageModel(response);
                 }
             });

        public ICommand BackCommand => new Command(
             async () =>
             {
                 await CoreMethods.PopPageModel();
             });

        public ICommand SelectImageCommand => new Command(
           async () =>
           {
               Stream stream = await DependencyService.Get<IImageService>().SelectImage();
               if (stream != null)
               {
                   Image = stream;
               }
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
        }
    }
}
