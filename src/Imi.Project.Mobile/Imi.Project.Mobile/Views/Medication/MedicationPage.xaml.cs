using Imi.Project.Mobile.Domain.Services.Mocking;
using Imi.Project.Mobile.Domain.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views.Medication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedicationPage : ContentPage
    {
        IMedicationService medicationservice;
        IBirdService birdservice;
        public MedicationPage()
        {
            InitializeComponent();
            medicationservice = new MockMedicationService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var medications = await medicationservice.GetAllMedications();
            colvMedication.ItemsSource = medications;
        }

        private void colvMedication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnShowBirds_Clicked(object sender, EventArgs e)
        {

        }
    }
}