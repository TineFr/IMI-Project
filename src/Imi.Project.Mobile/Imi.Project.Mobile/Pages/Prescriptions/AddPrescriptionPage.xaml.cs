
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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