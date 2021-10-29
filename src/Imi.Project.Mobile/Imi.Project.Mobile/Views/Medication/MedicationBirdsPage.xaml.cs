using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.ViewModels;
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
    public partial class MedicationBirdsPage : ContentPage
    {
        private static IEnumerable<Bird> Birds;
        private static Core.Models.Medication Medication;

       
        public MedicationBirdsPage(Core.Models.Medication medication, IEnumerable<Bird> birds)
        {
            InitializeComponent();
            Birds = birds;
            Medication = medication;

        }

        protected override void OnAppearing()
        {
            BindingContext = new BirdMedicineViewModel(Medication);
            colvBirds.ItemsSource = Birds;
        }
        private async void colvBirds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}