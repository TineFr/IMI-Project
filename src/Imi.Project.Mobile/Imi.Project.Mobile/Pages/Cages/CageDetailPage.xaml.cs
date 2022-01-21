
using Imi.Project.Mobile.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class CageDetailPage : ContentPage
    {
        public CageDetailPage(CageModel cage)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
