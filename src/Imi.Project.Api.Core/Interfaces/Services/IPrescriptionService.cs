using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> ListAllPrescriptionsAsync();
        Task<Prescription> GetPrescriptionByIdAsync(Guid id);
        Task<Prescription> AddPrescriptionAsync(Prescription prescription);
        Task<Prescription> UpdatePrescriptionAsync(Prescription Pprescription);
        Task DeletePrescriptionAsync(Prescription Prescription);
        Task DeleteMultiple(List<Prescription> prescriptions);
        Task<IEnumerable<Prescription>> GetPrescriptionsByUserIdAsync(Guid id);

    }
}
