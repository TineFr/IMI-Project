using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Prescriptions
{
    public class PrescriptionDetailViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<PrescriptionRequestModel, PrescriptionModel> _prescriptionService;

        public PrescriptionDetailViewModel(IBaseApiService<PrescriptionRequestModel, PrescriptionModel> prescriptionService, IBaseApiService<BirdRequestModel, BirdModel> birdService)
        {
            _prescriptionService = prescriptionService;
        }

        #region properties
        public PrescriptionModel prescription { get; set; }
        public PrescriptionModel Prescription
        {
            get { return prescription; }
            set
            {
                prescription = value;
                RaisePropertyChanged(nameof(Prescription));
            }
        }
        #endregion

        public override void Init(object initData)
        {
            Prescription = initData as PrescriptionModel;
            base.Init(initData);
        }

        public override void ReverseInit(object value)
        {
            var updatedPrescription = value as PrescriptionModel;
            Prescription = updatedPrescription;
        }

        #region commands

        public ICommand RemoveBirdCommand => new Command<BirdModel>(
             async (BirdModel bird) =>
             {
                 Prescription.Birds.Remove(Prescription.Birds.FirstOrDefault(b => b.Id == bird.Id));
                 if (prescription.Birds.Count() == 0)
                 {
                     await _prescriptionService.DeleteAsync($"prescriptions/{prescription.Id}");
                     await CoreMethods.PopToRoot(true);
                 }
                 else
                 {
                     PrescriptionRequestModel model = new PrescriptionRequestModel
                     {
                         StartDate = Convert.ToDateTime(prescription.StartDate),
                         EndDate = Convert.ToDateTime(prescription.EndDate),
                         Birds = prescription.Birds.Select(b => b.Id).ToList(),
                         Medicine = prescription.Medicine.Id
                     };
                     var result = await _prescriptionService.UpdateAsync($"prescriptions/{Prescription.Id}", model);
                     Prescription = result;
                 }

             });
        public ICommand DeleteCommand => new Command(
             async () =>
             {
                 var action = await CoreMethods.DisplayAlert("Do you wish to delete this prescription?", null, "YES", "NO");
                 if (action)
                 {
                     await _prescriptionService.DeleteAsync($"prescriptions/{prescription.Id}");
                     await CoreMethods.PopToRoot(true);
                 }
             });

        #endregion


    }

}
