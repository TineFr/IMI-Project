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
    public partial class BirdDetailPage : ContentPage
    {
        private static Bird birddetail;
        public BirdDetailPage(Bird bird)
        {
            InitializeComponent();
            birddetail = bird;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            BindingContext = new BirdDetailViewModel(birddetail);
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnEditBird_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditBirdPage(birddetail));
        }
    }
}