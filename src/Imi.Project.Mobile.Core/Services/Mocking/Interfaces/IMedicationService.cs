using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services.Mocking.Interfaces
{
    public interface IMedicationService
    {
        Task<ObservableCollection<MedicineModel>> GetAllMedications();
        Task<MedicineModel> GetMedicationById(Guid id);
        Task<MedicineModel> AddMedication(MedicineModel medication);
        Task<MedicineModel> UpdateMedication(MedicineModel medication);
        Task<MedicineModel> DeleteMedication(Guid id);
    }
}
