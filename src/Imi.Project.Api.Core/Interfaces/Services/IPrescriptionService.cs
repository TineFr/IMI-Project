using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> ListAllPrescriptionsAsync();
        Task<PrescriptionResponseDto> GetPrescriptionByIdAsync(Guid id);
        Task<PrescriptionResponseDto> AddPrescriptionAsync(PrescriptionRequestDto prescription);
        Task<PrescriptionResponseDto> UpdatePrescriptionAsync(Guid id, PrescriptionRequestDto Pprescription);
        Task DeletePrescriptionAsync(Guid id);
        Task DeleteMultiple(List<Prescription> prescriptions);
        Task<IEnumerable<Prescription>> GetPrescriptionsByUserIdAsync(Guid id);

    }
}
