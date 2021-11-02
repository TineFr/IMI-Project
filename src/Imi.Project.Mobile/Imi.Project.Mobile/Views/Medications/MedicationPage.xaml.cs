
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;

namespace Imi.Project.Mobile.Views.Medications
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedicationPage : ContentPage
    {
        IMedicationService medicationservice;
        IBirdService birdservice;
        IPrescriptionService prescriptionService;
        public MedicationPage()
        {
            InitializeComponent();
            medicationservice = new MockMedicationService();
            birdservice = new MockBirdService();
            prescriptionService = new MockPrescriptionService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            colvMedication.ItemsSource = await medicationservice.GetAllMedications();

        }


        private async void btnAddMedication_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMedicationPage());
        }

        private async void btnEditMedication_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnDeleteMedication_Clicked(object sender, EventArgs e)
        {

        }
    }
}