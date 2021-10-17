using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BirdDetailPage : ContentPage
    {
        public BirdDetailPage(Bird bird)
        {
            InitializeComponent();
            BindingContext = new BirdDetailViewModel(bird);
        }
    }
}