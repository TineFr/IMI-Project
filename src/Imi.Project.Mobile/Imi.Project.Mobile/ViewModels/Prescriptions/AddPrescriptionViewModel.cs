using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using Imi.Project.Mobile.ViewModels.Medications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels.Prescriptions
{
    public class AddPrescriptionViewModel : FreshBasePageModel
    {

        private readonly IBirdService _birdService;
        private readonly IMedicationService _medicationService;
        private readonly IPrescriptionService _prescriptionService;
        public AddPrescriptionViewModel(IBirdService birdService, IMedicationService medicationService, IPrescriptionService prescriptionService)
        {
            _birdService = birdService;
            _medicationService = medicationService;
            _prescriptionService = prescriptionService;
        }
        #region properties

        private ObservableCollection<Bird> birds;

        public ObservableCollection<Bird> Birds
        {
            get { return birds; }
            set
            { 
                birds = value;
                RaisePropertyChanged(nameof(Birds));
            }
        }


        private ObservableCollection<Medication> medications;

        public ObservableCollection<Medication> Medications
        {
            get { return medications; }
            set 
            {
                medications = value;
                RaisePropertyChanged(nameof(Medications));
            }

        }


        private Medication medication;

        public Medication Medication
        {
            get { return medication; }
            set
            { 
                medication = value;
                RaisePropertyChanged(nameof(Medication));
            }
        }

        private Bird bird;

        public Bird Bird
        {
            get { return bird; }
            set { bird = value; }
        }


        //private List<Guid> selectedBirds;

        //public List<Guid> SelectedBirds
        //{
        //    get { return selectedBirds; }
        //    set
        //    {
        //        selectedBirds = value;
        //        RaisePropertyChanged(nameof(SelectedBirds));
        //    }
        //}

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
            Medications = await _medicationService.GetAllMedications();
            Birds = await _birdService.GetAllBirds();
            base.Init(initData);
        }

        #region commands

        public ICommand SaveCommand => new Command(
             async () =>
             {
                 Prescription newPrescription = new Prescription
                 {
                     Id = new Guid(),
                     StartDate = this.StartDate.ToString("d"),
                     EndDate = this.EndDate.ToString("d"),
                     MedicationId = this.Medication.Id,
                     //BirdIds =  new List<Guid> 
                     //{
                     //    this.Bird.Id
                     //},
                     Birds = new ObservableCollection<Bird>
                     {
                         this.Bird
                     }
                     
                 };

                 //    bird.Prescriptions.Add(newPrescription.Id);
                 await _prescriptionService.AddPrescription(newPrescription);
                 var bird = await _birdService.GetBirdById(Bird.Id);
                 bird.Prescriptions.Add(newPrescription.Id);
                 await _birdService.UpdateBird(bird);
                 await CoreMethods.PopPageModel();
             });
        public ICommand ShowMedicationsCommand => new Command(
             async () =>
             {
                 await CoreMethods.PushPageModel<MedicationsViewModel>();
             });


        #endregion



        //private async void btnSave_Clicked(object sender, EventArgs e)
        //{
        //    var medication = await medicationService.GetAllMedications();
        //    var birds = await birdService.GetAllBirds();


        //    Prescription newPrescription = new Prescription
        //    {
        //        Id = new Guid(),
        //        MedicationId = medication.ToArray()[pkrMedicine.SelectedIndex].Id,
        //        BirdIds = new List<Guid>
        //        {
        //            birds.ToArray()[pkrBirds.SelectedIndex].Id
        //        },
        //        StartDate = pkrStartDate.Date.ToString("d"),
        //        EndDate = pkrEndDate.Date.ToString("d")
        //    };
        //    var bird = await birdService.GetBirdById(birds.ToArray()[pkrBirds.SelectedIndex].Id);
        //    bird.Prescriptions.Add(newPrescription.Id);
        //    await PrescriptionService.AddPrescription(newPrescription);
        //    await Navigation.PopAsync();
        //}

        //private void btnAddMedicine_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new MedicationsPage());
        //}

    }
}
