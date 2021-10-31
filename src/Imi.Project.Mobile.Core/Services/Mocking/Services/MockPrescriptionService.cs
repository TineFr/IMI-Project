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

        private static ObservableCollection<Prescription> prescriptionrepository = new ObservableCollection<Prescription>
        {
                    new Prescription
                    {
                    Id = Guid.Parse("E7FE31F2-1996-4102-90E3-9530A0838217"),
                    Medicine = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Birds = new List<Guid>
                    {
                        Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                        Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62")
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5)
                    

                    },
                    new Prescription
                    {
                    Id = Guid.Parse("29B764DE-09A7-47BA-95E8-70B7FAF7908A"),
                    Medicine = Guid.Parse("4ab9d646-7010-479c-ae3e-8fe6cd15c687"),
                    Birds = new List<Guid>
                    {
                        Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                        Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62")
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5)
                    },

                    new Prescription
                    {
                    Id = Guid.Parse("64571D4B-A65F-41D1-B8A2-2B371D6FAFF2"),
                    Medicine = Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62"),
                    Birds = new List<Guid>
                    {
                        Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                        Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62")
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5)
                    },

                    new Prescription
                    {
                    Id = Guid.Parse("3D5883D5-F0F8-46E4-BF80-0B2FEA7503A3"),
                    Medicine = Guid.Parse("8b9d60ed-ba62-439e-89e8-d0097dc62b58"),
                    Birds = new List<Guid>
                    {
                        Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                        Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62")
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5)
                    },
        };
        public Task<Prescription> AddPrescription(Prescription prescription)
        {
            prescriptionrepository.Add(prescription);
            return Task.FromResult(prescription);
        }


        public Task<ObservableCollection<Prescription>> GetAllPrescriptions()
        {
            
            return Task.FromResult(prescriptionrepository);
        }

        public Task<Prescription> GetPrescriptionById(Guid id)
        {
            var prescription = prescriptionrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(prescription);
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
    }
}
