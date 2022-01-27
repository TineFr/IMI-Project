using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Core;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Plugin.Media.Abstractions;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class AddCageViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;
        private readonly IValidator<CageRequestModel> _cageRequestModelValidator;

        public AddCageViewModel(IBaseApiService<CageRequestModel, CageModel> cageService,
                                IValidator<CageRequestModel> validator)
        {
            _cageService = cageService;
            _cageRequestModelValidator = validator;
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

        private ImageSource preview;

        public ImageSource Preview
        {
            get { return preview; }
            set
            {
                preview = value;
                RaisePropertyChanged(nameof(Preview));
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


        #region commands

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 CageRequestModel newCage = new CageRequestModel
                 {
                     Name = this.Name,
                     Location = this.Location,
                 };
                 if (Image != null) newCage.ImageInfo = new ImageInfo { FileName = "name.png", Image = this.Image };

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

        public ICommand SelectImageCommand => new Command(
           async () =>
           {
               Stream stream = await DependencyService.Get<IImageService>().SelectImage();
               if (stream != null)
               {
                   Image = stream;
               }
           });

        public ICommand TakeImage => new Command(
           async () =>
           {
               var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 600 } );

               if (photo != null)
               {
                   Preview = ImageSource.FromStream(() => { return photo.GetStream(); });
                   Image = photo.GetStream();
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
