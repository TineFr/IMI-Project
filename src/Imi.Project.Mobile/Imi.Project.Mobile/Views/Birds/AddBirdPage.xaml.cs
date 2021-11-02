using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBirdPage : ContentPage
    {
        ISpeciesService speciesService;
        IBirdService birdService;
        ICageService CageService;
        public AddBirdPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            birdService = new MockBirdService();
            speciesService = new MockSpeciesService();
            CageService = new MockCageService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var species = await speciesService.GetAllSpecies();
            var cages = await CageService.GetAllCages();
            pkrGender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                                                                    .Select(g => g.ToString())
                                                                    .ToList();
            BindingContext = new AddBirdViewModel(species, cages);
        }
        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var cages = await CageService.GetAllCages();
            var species = await speciesService.GetAllSpecies();
            Bird newBird = new Bird
            {
                Id = new Guid(),
                Name = entrName.Text,
                Species = species.ToArray()[pkrSpecies.SelectedIndex].Name,
                ScientificName = species.ToArray()[pkrSpecies.SelectedIndex].ScientificName,
                Cage = cages.ToArray()[pkrCage.SelectedIndex].Name,
                Gender = pkrGender.SelectedItem.ToString(),
                Food = entrFood.Text,
                Image = "budgie1.jpg"
            };
            await birdService.AddBird(newBird);

            await Navigation.PopAsync();
        }
    }
}