using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views.SpeciesGuide
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeciesPage : ContentPage
    {
        ISpeciesService speciesService;

        public SpeciesPage()
        {
            InitializeComponent();
            speciesService = new MockSpeciesService();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var species = await speciesService.GetAllSpecies();
            colvSpecies.ItemsSource = species;
        }

        private async void colvSpecies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = (CollectionView)sender;
            var species = selection.SelectedItem as Species;
            if (species == null) return;
            await Navigation.PushAsync(new SpeciesDetailPage(species));
        }
    }
}