using FreshMvvm;
using Imi.Project.Common.Enums;
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
        private readonly IBirdService birdService;
        private readonly ICageService cageService;
        private readonly ISpeciesService speciesService;
        public EditBirdViewModel(IBirdService birdService, ICageService cageService, ISpeciesService speciesService)
        {
            this.birdService = birdService;
            this.cageService = cageService;
            this.speciesService = speciesService;
        }


        private Bird birdToEdit;
        #region properties

        private ObservableCollection<Cage> cagesList;
        public ObservableCollection<Cage> CagesList
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
            }
        }

        private ObservableCollection<Species> speciesList;
        public ObservableCollection<Species> SpeciesList
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

        private Cage cage;
        public Cage Cage
        {
            get { return cage; }
            set
            {
                cage = value;
                RaisePropertyChanged(nameof(Cage));
            }
        }
        private Species species;
        public Species Species
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
                 birdToEdit.Name = Name;
                 birdToEdit.Gender = Gender;
                 birdToEdit.HatchDate = HatchDate;
                 birdToEdit.Species = Species;
                 birdToEdit.Cage = Cage;
                 birdToEdit.Food = Food;
                 birdToEdit.Image = Image;
                 await birdService.UpdateBird(birdToEdit);
                 await CoreMethods.PopPageModel(birdToEdit);
             });
        public ICommand DeleteCommand => new Command(
             async () =>
             {
                 var action = await CoreMethods.DisplayAlert("Do you wish to delete this bird?", null, "YES", "NO");
                 if (action)
                 {
                     await birdService.DeleteBird(birdToEdit.Id);
                     await CoreMethods.PopToRoot(true);
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
            var species = await speciesService.GetAllSpecies();
            SpeciesList = new ObservableCollection<Species>(species);
            var cages = await cageService.GetAllCages();
            CagesList = new ObservableCollection<Cage>(cages);

            Genders = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                                                    .Select(g => g.ToString())
                                                    .ToList();


            birdToEdit = initData as Bird;
            Name = birdToEdit.Name;
            Gender = birdToEdit.Gender;
            HatchDate = birdToEdit.HatchDate;
            Cage = birdToEdit.Cage;
            Species = birdToEdit.Species;
            Food = birdToEdit.Food;
            Image = "birds/budgie2.png";
            base.Init(initData);

        }
    }
}
