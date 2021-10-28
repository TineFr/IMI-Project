using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Mocking;
using Imi.Project.Mobile.Domain.Services.Mocking.Services;
using Imi.Project.Mobile.Views.Cages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CagesPage : ContentPage
    {
        ICageService cageservice;
        public CagesPage()
        {
            InitializeComponent();
            cageservice = new MockCageService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var cages = await cageservice.GetAllCages();
            colvCages.ItemsSource = cages;
        }

        private async void colvCages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = (CollectionView)sender;
            var cage = selection.SelectedItem as Cage;
            if (cage == null) return;
            await Navigation.PushAsync(new CageDetailPage(cage));

        }

        private async void btnAddCage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCagePage());
        }
    }
}