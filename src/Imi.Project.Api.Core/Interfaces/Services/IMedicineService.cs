using Imi.Project.Api.Core.Dtos.Medicines;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IMedicineService

    {
        Task<IEnumerable<Medicine>> ListAllMedicinesAsync();
        Task<Medicine> GetMedicineByIdAsync(Guid id);
        Task<Medicine> AddMedicineAsync(MedicineRequestDto MedicineRequestDto);
        Task<Medicine> UpdateMedicineAsync(MedicineRequestDto MedicineRequestDto);
        Task DeleteMedicineAsync(MedicineRequestDto userRequestDto);
        Task<IEnumerable<Medicine>> GetMedicinesByUserIdAsync(Guid id);
     
    }
}
