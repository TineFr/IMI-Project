using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.ViewModels;
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
    public partial class PrescriptionDetailPage : ContentPage
    {

        public Prescription Prescription { get; set; }

        public PrescriptionDetailPage(Prescription prescription)
        {
            InitializeComponent();
            Prescription = prescription;
        }


        protected override void OnAppearing()
        {
            BindingContext = new PrescriptionDetailViewModel(Prescription);
            colvBirds.ItemsSource = Prescription.Birds;
        }

        private void btnRemoveBird_Clicked(object sender, EventArgs e)
        {

        }
    }
}

