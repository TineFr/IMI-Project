using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services.Mocking.Services
{
    public class MockPrescriptionService : IPrescriptionService
    {
        private static IMedicationService medicationrepository = new MockMedicationService();
        private static IBirdService birdrepository = new MockBirdService();

        private static ObservableCollection<Prescription> prescriptionrepository = new ObservableCollection<Prescription>
        {
                    new Prescription
                    {
                    Id = Guid.Parse("E7FE31F2-1996-4102-90E3-9530A0838217"),
                    MedicationId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    BirdIds = new List<Guid>
                    {   
                        Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),

                    },
                    StartDate = DateTime.Now.ToString("d"),
                    EndDate = DateTime.Now.AddDays(5).ToString("d"),
                    Birds = new List<Bird>()

                    },
                    new Prescription
                    {
                    Id = Guid.Parse("5206461d-3ba9-4701-a6a1-6a563ccceff2"),
                    MedicationId = Guid.Parse("8b9d60ed-ba62-439e-89e8-d0097dc62b58"),
                    BirdIds = new List<Guid>
                    {
                        Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                        Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422")
                    },
                    StartDate = DateTime.Now.ToString("d"),
                    EndDate = DateTime.Now.AddDays(5).ToString("d"),
                    Birds = new List<Bird>()


                    },
                    new Prescription
                    {
                    Id = Guid.Parse("bd2670bb-392c-44a9-b2d8-88e6e413c165"),
                    MedicationId =Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62"),
                    BirdIds = new List<Guid>
                    {
                        Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                        Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422")
                    },
                    StartDate = DateTime.Now.ToString("d"),
                    EndDate = DateTime.Now.AddDays(5).ToString("d"),
                    Birds = new List<Bird>()

                    },
                    new Prescription
                    {
                    Id = Guid.Parse("6cdff968-d2fb-45af-a916-957a00ff5fe1"),
                    MedicationId = Guid.Parse("4ab9d646-7010-479c-ae3e-8fe6cd15c687"),
                    BirdIds = new List<Guid>
                    {
                         Guid.Parse("F797C0C1-B01A-4F54-9C5D-7C66D5EDDC52"),
                         Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                         Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                         Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E")

                    },
                    StartDate = DateTime.Now.ToString("d"),
                    EndDate = DateTime.Now.AddDays(5).ToString("d"),
                    Birds = new List<Bird>()

                    },
        };
        public Task<Prescription> AddPrescription(Prescription prescription)
        {
            prescriptionrepository.Add(prescription);
            return Task.FromResult(prescription);
        }


        public Task<ObservableCollection<Prescription>> GetAllPrescriptions()
        {
            prescriptionrepository.ToList().ForEach(async c => c.Medication = await GetMedicationByPrescription(c));
            prescriptionrepository.ToList().ForEach(p => p.Birds = birdrepository.GetBirdsByPrescription(p));
            return Task.FromResult(prescriptionrepository);        
        }

        public Task<Prescription> GetPrescriptionById(Guid id)
        {
            var prescription = prescriptionrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(prescription);
        }


        public  Task<Medication> GetMedicationByPrescription(Prescription prescription)
        {
            var medication =  medicationrepository.GetMedicationById(prescription.MedicationId);
            return medication;
        }


        public Task<Prescription> UpdatePrescription(Prescription updatedPrescription)
        {
            var prescription = prescriptionrepository.FirstOrDefault(b => b.Id.Equals(updatedPrescription.Id));
            prescriptionrepository.ToList().Remove(prescription);
            prescriptionrepository.ToList().Add(updatedPrescription);
            return Task.FromResult(updatedPrescription);
        }

        Task<Prescription> IPrescriptionService.DeletePrescription(Guid id)
        {
            var prescription = prescriptionrepository.FirstOrDefault(b => b.Id.Equals(id));
            prescriptionrepository.Remove(prescription);
            return Task.FromResult(prescription);
        }

        //public async void GetBirdsByPrescription(Prescription prescription)
        //{

        //    prescription.BirdIds.ToList().ForEach(  b => prescription.Birds.ToList().Add( await birdrepository.GetBirdById(b)));

        //    foreach (var bird in prescription.BirdIds)
        //    {
        //        prescription.Birds.ToList().Add(birdrepository.GetBirdById(bird))
        //    }
            

        //}
    }
}
