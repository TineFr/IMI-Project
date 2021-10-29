using Imi.Project.Mobile.Core.Models;
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
        public List<Bird> Birds { get; set; }
        public MedicationBirdsPage(IEnumerable<Bird> birds)
        {
            InitializeComponent();
            Birds = birds.ToList();

        }

        protected override void OnAppearing()
        {
            colvBirds.ItemsSource = Birds; 
        }
        private void colvBirds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}