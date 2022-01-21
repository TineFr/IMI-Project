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

namespace Imi.Project.Mobile.Pages.Medicines
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMedicinePage : ContentPage
    {
        public EditMedicinePage(MedicineModel medication)
        {
            InitializeComponent();
        }

    }
}