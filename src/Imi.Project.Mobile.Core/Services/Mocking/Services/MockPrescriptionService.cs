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
                    MedicationId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    BirdIds = new List<Guid>
                    {
                        Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                        Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62")
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5)
                    

                    },
                    new Prescription
                    {
                    Id = Guid.Parse("5206461d-3ba9-4701-a6a1-6a563ccceff2"),
                    MedicationId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    BirdIds = new List<Guid>
                    {
                        Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                        Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62")
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5)


                    },
                    new Prescription
                    {
                    Id = Guid.Parse("bd2670bb-392c-44a9-b2d8-88e6e413c165"),
                    MedicationId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    BirdIds = new List<Guid>
                    {
                        Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                        Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62")
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5)


                    },
                    new Prescription
                    {
                    Id = Guid.Parse("6cdff968-d2fb-45af-a916-957a00ff5fe1"),
                    MedicationId = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    BirdIds = new List<Guid>
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
