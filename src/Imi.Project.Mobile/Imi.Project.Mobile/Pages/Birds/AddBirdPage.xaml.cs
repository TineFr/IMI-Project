using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Birds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBirdPage : ContentPage
    {

        public AddBirdPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

    }
}