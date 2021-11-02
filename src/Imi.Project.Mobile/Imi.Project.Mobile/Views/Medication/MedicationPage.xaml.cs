
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;

namespace Imi.Project.Mobile.Views.Medication
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



        private async void colvMedication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private async void btnShowBirds_Clicked(object sender, EventArgs e)
        {
            //var selection = (Button)sender;
            //var medication = selection.CommandParameter as Core.Models.Medication;
            //if (medication == null) return;
            //var birds = birdservice.GetBirdsByMedication(medication);
            //await Navigation.PushAsync(new MedicationDetailPage(medication, birds));
        }

        private async void btnAddMedication_Clicked(object sender, EventArgs e)
        {

        }
    }
}