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

namespace Imi.Project.Mobile.Pages.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CagesPage : ContentPage
    {



        public CagesPage()
        {
            InitializeComponent();
            //cageservice = new MockCageService();
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var cages = await cageservice.GetAllCages();
        //    colvCages.ItemsSource = cages;
        //}


        private async void btnAddCage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCagePage());
        }
    }
}