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
        Task<ObservableCollection<Medication>> GetAllMedications();
        Task<Medication> GetMedicationById(Guid id);
        Task<Medication> AddMedication(Medication medication);
        Task<Medication> UpdateMedication(Medication medication);
        Task<Medication> DeleteMedication(Guid id);
    }
}
