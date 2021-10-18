using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.ViewModels;
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
        public EditBirdPage(Bird bird)
        {
            InitializeComponent();
            birdToEdit = bird;
            BindingContext = new EditBirdViewModel(birdToEdit);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {

        }
    }
}