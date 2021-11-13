using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Birds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBirdPage : ContentPage
    {
        private static Bird birdToEdit;
        ISpeciesService speciesService;
        IBirdService birdService;
        ICageService CageService;
        public EditBirdPage(Bird bird)
        {
            InitializeComponent();
            birdToEdit = bird;
            birdService = new MockBirdService();
            speciesService = new MockSpeciesService();
            CageService = new MockCageService();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var species = await speciesService.GetAllSpecies();
            var cages = await CageService.GetAllCages();
            BindingContext = new EditBirdViewModel(birdToEdit, species, cages);
            pkrGender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                                                        .Select(g => g.ToString())
                                                        .ToList();
            pkrGender.SelectedItem = birdToEdit.Gender;
            pkrCage.SelectedItem = birdToEdit.Cage;
            pkrSpecies.SelectedItem = birdToEdit.Species;
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var cages = await CageService.GetAllCages();
            var species = await speciesService.GetAllSpecies();
            birdToEdit.Gender = pkrGender.SelectedItem.ToString();
            birdToEdit.SpeciesId = species.ToArray()[pkrSpecies.SelectedIndex].Id;
            birdToEdit.CageId = cages.ToArray()[pkrCage.SelectedIndex].Id;
            birdToEdit.Species = species.ToArray()[pkrSpecies.SelectedIndex];
            birdToEdit.Cage = cages.ToArray()[pkrCage.SelectedIndex];
            await birdService.UpdateBird(birdToEdit);
            await Navigation.PopAsync();

        }

        private async void btnRemove_Clicked(object sender, EventArgs e)
        {
            await birdService.DeleteBird(birdToEdit.Id);
            await Navigation.PopToRootAsync();

        }

    }
}