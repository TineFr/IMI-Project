using Imi.Project.Api.Core.Dtos.Medicines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IMedicineService

    {
        Task<IEnumerable<MedicineResponseDto>> ListAllMedicinesAsync();
        Task<MedicineResponseDto> GetMedicineByIdAsync(Guid id);
        Task<MedicineResponseDto> AddMedicineAsync(MedicineRequestDto MedicineRequestDto);
        Task<MedicineResponseDto> UpdateMedicineAsync(MedicineRequestDto MedicineRequestDto);
        Task DeleteMedicineAsync(MedicineRequestDto userRequestDto);
        Task<IEnumerable<MedicineResponseDto>> GetMedicinesByUserIdAsync(Guid id);
     
    }
}
