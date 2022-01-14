using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IMedicineService

    {
        Task<IEnumerable<MedicineResponseDto>> ListAllMedicinesAsync(PaginationParameters parameters);
        Task<MedicineResponseDto> GetMedicineByIdAsync(Guid id);
        Task<MedicineResponseDto> AddMedicineAsync(MedicineRequestDto medicine);
        Task<MedicineResponseDto> UpdateMedicineAsync(Guid id, MedicineRequestDto medicine);
        Task DeleteMedicineAsync(Guid id);
        Task DeleteMultiple(List<Medicine> medicines);
        Task<IEnumerable<MedicineResponseDto>> GetMedicinesByUserIdAsync(Guid id, PaginationParameters parameters);

    }
}
