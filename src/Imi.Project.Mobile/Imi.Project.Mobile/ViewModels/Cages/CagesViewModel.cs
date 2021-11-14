using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class CagesViewModel : FreshBasePageModel
    {

        MockCageService cageservice = new MockCageService();

        #region properties


        private ObservableCollection<Cage> cages;
        public ObservableCollection<Cage> Cages
        {
            get { return cages; }
            set
            {
                cages = value;
                RaisePropertyChanged(nameof(Cages));
            }
        }
        #endregion
        public override void Init(object initData)
        {
            base.Init(initData);
            ShowCagesCommand.Execute(null);
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await RefreshCages();
        }

 
        private async Task RefreshCages()
        {
            var cages = await cageservice.GetAllCages();
            Cages = null;    
            Cages = new ObservableCollection<Cage>(cages);
        }

        #region commands
        public ICommand ShowCagesCommand => new Command(
         async () => {
             Cages = await cageservice.GetAllCages();
         });

        public ICommand ViewCageCommand => new Command<Cage>(
            async (Cage cage) =>
            {
                var test = cage;
                await CoreMethods.PushPageModel<CageDetailViewModel>(cage);
            });
        public ICommand AddCageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<AddCageViewModel>();
            });
        #endregion

    }
}
