using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages.Birds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BirdsPage : ContentPage
      
    {
        public BirdsPage()
        {
            InitializeComponent();
        }
    }
}