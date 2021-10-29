using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
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
        IBirdService birdservice;
        public AddBirdPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            birdservice = new MockBirdService();
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Bird newBird = new Bird
            {
                Id = new Guid(),
                Name = entrName.Text,
                //ScientificName = (Species)pkrCage.SelectedItem,
                //Gender = entrGender.Text,
                //Species = entrSpecies.Text,
                Image = "budgie1.jpg"
            };
            await birdservice.AddBird(newBird);

            await Navigation.PopAsync();
        }
    }
}