using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking
{
    public interface IMedicationService
    {
        Task<ObservableCollection<Medication>> GetAllMedications();
        Task<Medication> GetMedicationById(Guid id);
        Task<Medication> AddMedication(Medication Medication);
        Task<Medication> UpdateMedication(Medication Medication);
        Task<Medication> DeleteMedication(Guid id);
    }
}
