using FluentValidation;
using FreshMvvm;
using Imi.Project.Common.Enums;
using Imi.Project.Mobile.Core;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Birds
{
    public class EditBirdViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesService;
        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdService;
        private readonly IValidator<BirdRequestModel> _birdRequestModelValidator;
        public EditBirdViewModel(IBaseApiService<CageRequestModel, CageModel> cageService,
                                IBaseApiService<SpeciesModel, SpeciesModel> speciesService,
                                IBaseApiService<BirdRequestModel, BirdModel> birdService,
                                 IValidator<BirdRequestModel> validator)
        {
            _cageService = cageService;
            _speciesService = speciesService;
            _birdService = birdService;
            _birdRequestModelValidator = validator;
        }


        private BirdModel birdToEdit;
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
                 BirdRequestModel model = new BirdRequestModel
                 {
                     Name = this.Name,
                     HatchDate = this.HatchDate,
                     CageId = Cage?.Id,
                     SpeciesId = Species?.Id,
                     Food = this.Food,
                 };
                 if (Gender != null) model.Gender = (Gender)Enum.Parse(typeof(Gender), Gender);
                 if (Image != null) model.ImageInfo = new ImageInfo { FileName = "name.png", Image = this.Image };
                 var isValid = Validate(model);
                 if (isValid)
                 {
                     var response = await _birdService.UpdateAsync($"birds/{birdToEdit.Id}", model);
                     if (response.ErrorMessage is object)
                     {
                         await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "Ok");
                     }
                     else await CoreMethods.PopPageModel(response);
                 }
             });
        public ICommand DeleteCommand => new Command(
             async () =>
             {
                 var action = await CoreMethods.DisplayAlert("Do you wish to delete this bird?", null, "YES", "NO");
                 if (action)
                 {
                     var response = await _cageService.DeleteAsync($"birds/{birdToEdit.Id}");
                     if (response is object)
                     {
                         await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "OK");
                     }
                     else await CoreMethods.PopToRoot(true);
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
               var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 600 });

               if (photo != null)
               {
                   Preview = ImageSource.FromStream(() => { return photo.GetStream(); });
                   Image = photo.GetStream();
               }
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


            birdToEdit = initData as BirdModel;
            Name = birdToEdit.Name;
            Gender = birdToEdit.Gender.ToString();
            HatchDate = birdToEdit.HatchDate;
            Cage = CagesList.Where(c => c.Name == birdToEdit.Cage?.Name).FirstOrDefault();
            Species = SpeciesList.Where(c => c.Name == birdToEdit.Species?.Name).FirstOrDefault();
            Food = birdToEdit.Food;
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
