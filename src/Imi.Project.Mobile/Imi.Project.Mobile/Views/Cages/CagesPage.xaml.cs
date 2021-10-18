using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CagesPage : ContentPage
    {
        public CagesPage()
        {
            InitializeComponent();
        }

        private void colvCages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var bird = e.CurrentSelection as Bird
            //if (bird == null) return;
            //await Navigation.PushAsync(new BirdDetailPage(bird));
            //((CollectionView)sender).SelectedItem = null;

        }
    }
}