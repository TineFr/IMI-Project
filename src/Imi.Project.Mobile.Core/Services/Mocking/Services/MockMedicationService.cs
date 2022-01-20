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
    public class MockMedicationService : IMedicationService
    {
        private static ObservableCollection<MedicineModel> medicationrepository = new ObservableCollection<MedicineModel>
        {
                    new MedicineModel
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "Acox",
                    Usage = "7 ml per liter drinking water",

                    
                    },
                    new MedicineModel
                    {
                    Id = Guid.Parse("4ab9d646-7010-479c-ae3e-8fe6cd15c687"),
                    Name = "Baytril",
                    Usage = "0,3 ml per 500 ml drinking water",

                    },
                    new MedicineModel
                    {
                    Id = Guid.Parse("13931038-e515-45f4-b036-ea22c0c24d62"),
                    Name = "Amtyl",
                    Usage = "The easiest way to give Baytril to your Birds is mixing it up in their normal drinking water. Give 1ml of solution per 100grams of body weight.",

                    },
                    new MedicineModel
                    {
                    Id = Guid.Parse("8b9d60ed-ba62-439e-89e8-d0097dc62b58"),
                    Name = "Doxycycline",
                    Usage = " 1 tsp. per gallon of water",

                    },
        };
        public Task<MedicineModel> AddMedication(MedicineModel medication)
        {
            medicationrepository.Add(medication);
            return Task.FromResult(medication);
        }

        public Task<MedicineModel> DeleteMedication(Guid id)
        {
            var medication = medicationrepository.FirstOrDefault(b => b.Id.Equals(id));
            medicationrepository.Remove(medication);
            return Task.FromResult(medication);
        }

        public Task<ObservableCollection<MedicineModel>> GetAllMedications()
        {
            return Task.FromResult(medicationrepository);
        }


        public Task<MedicineModel> GetMedicationById(Guid id)
        {
            var medication = medicationrepository.FirstOrDefault(b => b.Id.Equals(id));
            return Task.FromResult(medication);
        }

        public Task<MedicineModel> UpdateMedication(MedicineModel updatedMedication)
        {
            var medication = medicationrepository.FirstOrDefault(b => b.Id.Equals(updatedMedication.Id));
            medicationrepository.ToList().Remove(medication);
            medicationrepository.ToList().Add(updatedMedication);
            return Task.FromResult(updatedMedication);
        }
    }
}
