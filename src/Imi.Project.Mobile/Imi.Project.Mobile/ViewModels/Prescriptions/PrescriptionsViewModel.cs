using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.Core.Services.Mocking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Imi.Project.Mobile.ViewModels.Prescriptions
{
    public class PrescriptionsViewModel : FreshBasePageModel
    {
        private const string prescriptionsMessage = "There are no prescriptions yet. Add a new prescription!";
        private readonly IBaseApiService<PrescriptionModel, PrescriptionModel> _prescriptionService;

        public PrescriptionsViewModel(IBaseApiService<PrescriptionModel, PrescriptionModel> prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }


        #region properties


        private ObservableCollection<PrescriptionModel> prescriptions;
        public ObservableCollection<PrescriptionModel> Prescriptions
        {
            get { return prescriptions; }
            set
            {
                prescriptions = value;
                RaisePropertyChanged(nameof(Prescriptions));
            }
        }

        private string noPrescriptionsMessage;

        public string NoPrescriptionsMessage
        {
            get { return noPrescriptionsMessage; }
            set
            {
                noPrescriptionsMessage = value;
                RaisePropertyChanged(nameof(NoPrescriptionsMessage));
            }
        }
        #endregion


        public override void Init(object initData)
        {
            base.Init(initData);
            ShowPrescriptionsCommand.Execute(null);
        }



        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            NoPrescriptionsMessage = null;
            await RefreshPrescriptions();
        }


        private async Task RefreshPrescriptions()
        {
            Prescriptions = null;
            var prescriptions = await _prescriptionService.GetAllAsync("me/prescriptions/?Page=1&ItemsPerPage=100");
            if (prescriptions.ToList()[0].ErrorMessage is object) NoPrescriptionsMessage = prescriptionsMessage;
            else Prescriptions = new ObservableCollection<PrescriptionModel>(prescriptions);
        }


        #region commands
        public ICommand ShowPrescriptionsCommand => new Command(
         async () => {

             await RefreshPrescriptions();
         });
        public ICommand ViewPrescriptionCommand => new Command<PrescriptionModel>(
             async (PrescriptionModel prescription) =>
             {
                 await CoreMethods.PushPageModel<PrescriptionDetailViewModel>(prescription);
             });
        public ICommand AddPrescriptionCommand => new Command(
             async () =>
             {
                 await CoreMethods.PushPageModel<AddPrescriptionViewModel>();
             });

        #endregion
    }
}
