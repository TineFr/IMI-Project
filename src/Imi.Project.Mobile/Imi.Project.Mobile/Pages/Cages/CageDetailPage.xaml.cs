
using Imi.Project.Mobile.Core.Models;
using Plugin.FirebasePushNotification;
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
            CrossFirebasePushNotification.Current.OnNotificationOpened += Current_OnNotificationOpened;
        }

        private void Current_OnNotificationOpened(object source, FirebasePushNotificationResponseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Received");
            MessagingCenter.Send<CageDetailPage>(this, "Notification");
        }

    }
}
