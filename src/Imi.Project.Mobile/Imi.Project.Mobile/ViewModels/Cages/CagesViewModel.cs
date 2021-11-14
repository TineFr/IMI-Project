using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Cages
{
    public class CagesViewModel : FreshBasePageModel
    {

        MockCageService cageservice = new MockCageService();

        #region properties
        //private Cage selectedCage;


        //public Cage SelectedCage
        //{
        //    get 
        //    { 
        //        return selectedCage;

        //    }
        //    set
        //    {
        //        if (selectedCage != value)
        //        {
        //            selectedCage = value;
        //            RaisePropertyChanged(nameof(SelectedCage));

        //        }
        //    }
        //}

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

        public async override void Init(object initData)
        {
            base.Init(initData);

            ShowCagesCommand.Execute(null);
        }

        public CagesViewModel()
        {

        }

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


    }
}
