using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.ViewModels.Cages;
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
    public partial class EditCagePage : ContentPage
    {
        //private static Cage cageToEdit;
        //ICageService cageservice;
        public EditCagePage(Cage cage)
        {
            InitializeComponent();
            //cageToEdit = cage;
            //cageservice = new MockCageService();
            //BindingContext = new EditCageViewModel(cageToEdit);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnRemove_Clicked(object sender, EventArgs e)
        {
            //await cageservice.DeleteCage(cageToEdit.Id);
            await Navigation.PopToRootAsync();
        }

    }
}

