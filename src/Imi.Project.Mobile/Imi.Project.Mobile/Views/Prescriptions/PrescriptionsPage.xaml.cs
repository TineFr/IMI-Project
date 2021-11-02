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

namespace Imi.Project.Mobile.Views.Prescriptions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionsPage : ContentPage
    {

        IPrescriptionService prescriptionService;
        public PrescriptionsPage()
        {
            InitializeComponent();
            prescriptionService = new MockPrescriptionService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            colvPrescriptions.ItemsSource = await prescriptionService.GetAllPrescriptions();



        }

        private void colvPrescriptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void btnShowBirds_Clicked(object sender, EventArgs e)
        {
            var selection = (Button)sender;
            var prescription = selection.CommandParameter as Prescription;
            if (prescription == null) return;
          
            await Navigation.PushAsync(new PrescriptionDetailPage(prescription));
        }
    }
}