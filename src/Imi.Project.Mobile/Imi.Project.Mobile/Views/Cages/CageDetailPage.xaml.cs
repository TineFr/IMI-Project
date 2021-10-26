using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Views.Cages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CageDetailPage : ContentPage
    {
        public CageDetailPage(Cage cage)
        {
            InitializeComponent();
        }
    }
}