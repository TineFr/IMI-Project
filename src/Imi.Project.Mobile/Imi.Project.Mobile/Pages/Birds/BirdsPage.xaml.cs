using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Birds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BirdsPage : ContentPage
      
    {
        IBirdService birdservice;
        public BirdsPage()
        {
            InitializeComponent();
            birdservice = new MockBirdService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var birds = await birdservice.GetAllBirds();
            colvBirds.ItemsSource = birds;         
        }


        private async void colvBirds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = (CollectionView)sender;
            var bird = selection.SelectedItem as Bird;
            if (bird == null) return;
            await Navigation.PushAsync(new BirdDetailPage(bird));
        }

        private async void btnAddBird_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBirdPage());
        }
    }
}