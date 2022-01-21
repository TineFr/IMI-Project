using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Birds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BirdDetailPage : ContentPage
    {
        public BirdDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}