using Imi.Project.Mobile.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Prescriptions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionDetailPage : ContentPage
    {
        public PrescriptionDetailPage(PrescriptionModel prescription)
        {
            InitializeComponent();
        }

    }
}

