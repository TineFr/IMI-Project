using FreshMvvm;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.ViewModels.Medications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Prescriptions
{
    public class AddPrescriptionViewModel : FreshBasePageModel
    {
        private readonly IBaseApiService<BirdRequestModel, BirdModel> _birdService;
        private readonly IBaseApiService<MedicineModel, MedicineModel> _medicineService;
        private readonly IBaseApiService<PrescriptionModel, PrescriptionModel> _prescriptionService;
        public AddPrescriptionViewModel(IBaseApiService<PrescriptionModel, PrescriptionModel> prescriptionService,
                                        IBaseApiService<MedicineModel, MedicineModel> medicineService,
                                        IBaseApiService<BirdRequestModel, BirdModel> birdService)
        {
            _prescriptionService = prescriptionService;
            _birdService = birdService; 
            _medicineService = medicineService;
        }
        #region properties

        private ObservableCollection<BirdModel> birds;

        public ObservableCollection<BirdModel> Birds
        {
            get { return birds; }
            set
            { 
                birds = value;
                RaisePropertyChanged(nameof(Birds));
            }
        }


        private ObservableCollection<MedicineModel> medicines;

        public ObservableCollection<MedicineModel> Medicines
        {
            get { return medicines; }
            set 
            {
                medicines = value;
                RaisePropertyChanged(nameof(Medicines));
            }

        }


        private MedicineModel medicine;

        public MedicineModel Medicine
        {
            get { return medicine; }
            set
            {
                medicine = value;
                RaisePropertyChanged(nameof(Medicine));
            }
        }

        private BirdModel bird;

        public BirdModel Bird
        {
            get { return bird; }
            set
            {
                bird = value;
                RaisePropertyChanged(nameof(Bird));
            }
        }

        //private object medecine;

        //public object Medicine
        //{
        //    get { return medecine; }
        //    set
        //    {
        //        medecine = value;
        //        RaisePropertyChanged(nameof(Medicine));
        //    }
        //}


        private ObservableCollection<object> selectedBirds;

        public ObservableCollection<object> SelectedBirds
        {
            get { return selectedBirds; }
            set
            {
                selectedBirds = value;
                RaisePropertyChanged(nameof(SelectedBirds));
            }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        #endregion
        public async override void Init(object initData)
        {
            Medicines = new ObservableCollection<MedicineModel>(await _medicineService.GetAllAsync("me/medicines?ItemsPerPage=1000"));
            Birds = new ObservableCollection<BirdModel>(await _birdService.GetAllAsync("me/birds?ItemsPerPage=1000"));
            base.Init(initData);
        }

        #region commands

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 PrescriptionModel newPrescription = new PrescriptionModel
                 {
                     StartDate = this.StartDate.ToString(),
                     EndDate = this.EndDate.ToString(),
                     MedicationId = this.Medicine.Id,
                     BirdIds = SelectedBirds.Select(b => b as BirdModel).Select(b => b.Id).ToList(),
                 };

                 await _prescriptionService.AddAsync("prescriptions", newPrescription);
                 await CoreMethods.PopPageModel();
             });
        public ICommand ShowMedicationsCommand => new Command(
             async () =>
             {
                 await CoreMethods.PushPageModel<MedicationsViewModel>();
             });

        #endregion
    }
}
