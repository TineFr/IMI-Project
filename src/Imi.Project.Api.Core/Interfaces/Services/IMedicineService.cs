using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IMedicineService

    {
        Task<IEnumerable<Medicine>> ListAllMedicinesAsync();
        Task<MedicineResponseDto> GetMedicineByIdAsync(Guid id);
        Task<MedicineResponseDto> AddMedicineAsync(MedicineRequestDto medicine);
        Task<MedicineResponseDto> UpdateMedicineAsync(Guid id, MedicineRequestDto medicine);
        Task DeleteMedicineAsync(Guid id);
        Task DeleteMultiple(List<Medicine> medicines);
        Task<IEnumerable<Medicine>> GetMedicinesByUserIdAsync(Guid id);

    }
}
