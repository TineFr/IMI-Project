using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;


namespace Imi.Project.Mobile.Core.Services.Mocking.Interfaces
{
    public interface IPrescriptionService
    {
        Task<ObservableCollection<Prescription>> GetAllPrescriptions();
        Task<Prescription> AddPrescription(Prescription prescription);
        Task<Prescription> UpdatePrescription(Prescription updatedPrescription);
        Task<Prescription> DeletePrescription(Guid id);
        Task<Prescription> GetPrescriptionById(Guid id);
        //Task<Medication> GetMedicationByPrescription(Prescription prescription);
        //Task<IEnumerable<Task<Bird>>> GetBirdsByPrescription(Prescription prescription);
    }
}
