using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionResponseDto>> ListAllPrescriptionsAsync(PaginationParameters parameters);
        Task<PrescriptionResponseDto> GetPrescriptionByIdAsync(Guid id);
        Task<PrescriptionResponseDto> AddPrescriptionAsync(PrescriptionRequestDto prescription);
        Task<PrescriptionResponseDto> UpdatePrescriptionAsync(Guid id, PrescriptionRequestDto Pprescription);
        Task DeletePrescriptionAsync(Guid id);
        Task DeleteMultiple(List<Prescription> prescriptions);
        Task<IEnumerable<PrescriptionResponseDto>> GetPrescriptionsByUserIdAsync(Guid id, PaginationParameters parameters);

    }
}
