using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.Pages.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile.ViewModels.Prescriptions;

namespace Imi.Project.Mobile.Pages.Prescriptions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPrescriptionPage : ContentPage
    {
        public AddPrescriptionPage()
        {
            InitializeComponent();
        }

        private void cmbBirds_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            var test = cmbBirds.SelectedItem;

        }
    }
}