using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Medications
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMedicationPage : ContentPage
    {
        public EditMedicationPage(Medication medication)
        {
            InitializeComponent();
        }

    }
}