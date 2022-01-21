
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCagePage : ContentPage
    {
        public AddCagePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

    }
}