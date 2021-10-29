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

namespace Imi.Project.Mobile.Views.Birds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBirdPage : ContentPage
    {
        private static Bird birdToEdit;
        IBirdService birdservice;
        public EditBirdPage(Bird bird)
        {
            InitializeComponent();
            birdToEdit = bird;
            birdservice = new MockBirdService();
            BindingContext = new EditBirdViewModel(birdToEdit);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var updatedBird = new Bird
            {

                Name = entrName.Text,
                Cage = entrCage.Text,
                Gender = entrGender.Text,
                HatchDate = dpkHatchDate.Date
            };

            await birdservice.UpdateBird(updatedBird);
            await Navigation.PopAsync();
            
        }

        private async void btnRemove_Clicked(object sender, EventArgs e)
        {
            await birdservice.DeleteBird(birdToEdit.Id);
            await Navigation.PopToRootAsync();

        }

    }
}