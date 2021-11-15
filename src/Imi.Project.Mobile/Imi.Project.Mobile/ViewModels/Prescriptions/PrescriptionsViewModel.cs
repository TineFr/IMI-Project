using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Prescriptions
{
    public class PrescriptionsViewModel : FreshBasePageModel
    {
        private readonly IPrescriptionService prescriptionService;

        public PrescriptionsViewModel(IPrescriptionService prescriptionService)
        {
            this.prescriptionService = prescriptionService;
        }


        #region properties


        private ObservableCollection<Prescription> prescriptions;
        public ObservableCollection<Prescription> Prescriptions
        {
            get { return prescriptions; }
            set
            {
                prescriptions = value;
                RaisePropertyChanged(nameof(Prescriptions));
            }
        }
        #endregion

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await RefreshPrescriptions();
        }


        private async Task RefreshPrescriptions()
        {
            var prescriptions = await prescriptionService.GetAllPrescriptions();
            Prescriptions = null;
            Prescriptions = new ObservableCollection<Prescription>(prescriptions);
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            ShowPrescriptionsCommand.Execute(null);
        }


        #region commands
        public ICommand ShowPrescriptionsCommand => new Command(
             async () => {
                 Prescriptions = await prescriptionService.GetAllPrescriptions();
             });
        public ICommand ViewPrescriptionCommand => new Command<Prescription>(
             async (Prescription prescription) =>
             {
                 await CoreMethods.PushPageModel<PrescriptionDetailViewModel>(prescription);
             });
        public ICommand AddPrescriptionCommand => new Command<Prescription>(
             async (Prescription prescription) =>
             {
                 await CoreMethods.PushPageModel<AddPrescriptionViewModel>(prescription);
             });

        #endregion
    }
}
