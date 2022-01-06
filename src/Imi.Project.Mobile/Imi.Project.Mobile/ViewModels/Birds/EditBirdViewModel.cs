using FreshMvvm;
using Imi.Project.Common.Enums;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Birds
{
    public class EditBirdViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<CageRequestModel, CageModel> _cageService;
        private readonly IBaseApiService<SpeciesModel, SpeciesModel> _speciesService;
        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdService;
        public EditBirdViewModel(IBaseApiService<CageRequestModel, CageModel> cageService, 
                                IBaseApiService<SpeciesModel, SpeciesModel> speciesService, 
                                IBaseApiService<BirdRequestModel, BirdModel> birdService)
        {
            _cageService = cageService;
            _speciesService = speciesService;
            _birdService = birdService;
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

        #region commands
        public ICommand SaveCommand => new Command(
             async () =>
             {
                 BirdRequestModel model = new BirdRequestModel
                 {
                     Name = this.Name,
                     HatchDate = this.HatchDate,
                     CageId = Cage.Id,
                     SpeciesId = Species.Id,
                     Food = this.Food,
                     Gender = (Gender)Enum.Parse(typeof(Gender), Gender)
                 };

                 var response = await _birdService.UpdateAsync($"birds/{birdToEdit.Id}", model);
                 if (response.ErrorMessage is object)
                 {
                     await CoreMethods.DisplayAlert("Error", response.ErrorMessage, "Ok");
                 }
                 else await CoreMethods.PopPageModel(response);



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
            Cage = CagesList.Where(c => c.Name == birdToEdit.Cage.Name).FirstOrDefault();
            Species = SpeciesList.Where(c => c.Name == birdToEdit.Species.Name).FirstOrDefault();
            Food = birdToEdit.Food;
            Image = "birds/budgie2.png";
            base.Init(initData);

        }
    }
}
