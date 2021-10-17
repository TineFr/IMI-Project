using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Mocking;
using Imi.Project.Mobile.Domain.Services.Mocking.Repositories;
using Imi.Project.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
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


        private void colvBirds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var bird = e.CurrentSelection as Bird;
            if (bird == null) return;
            //await Navigation.PushAsync(new BirdDetailsPage(bird))
        }

        private async void btnAddBird_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBirdPage());
        }
    }
}