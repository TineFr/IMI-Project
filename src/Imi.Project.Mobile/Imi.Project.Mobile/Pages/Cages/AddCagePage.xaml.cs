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

namespace Imi.Project.Mobile.Pages.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCagePage : ContentPage
    {
        ICageService cageservice;
        public AddCagePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            cageservice = new MockCageService();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Cage newCage = new Cage
            {
                Id = new Guid(),
                Name = entrName.Text,
                Location = entrLocation.Text,
                Image = "cage1.png"
            };
            await cageservice.AddCage(newCage);

            await Navigation.PopAsync();
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}