using Imi.Project.Api.Core.Dtos.Medicines;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class MedicineService : IMedicineService
    {
        protected readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public Task<Medicine> AddMedicineAsync(MedicineRequestDto MedicineRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMedicineAsync(MedicineRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Medicine> GetMedicineByIdAsync(Guid id)
        {
            var medicine = await _medicineRepository.GetByIdAsync(id);
            return medicine;
        }

        public async  Task<IEnumerable<Medicine>> GetMedicinesByUserIdAsync(Guid id)
        {
            var medicines = await _medicineRepository.GetByUserIdAsync(id);
            return medicines;

        }

        public async Task<IEnumerable<Medicine>> ListAllMedicinesAsync()
        {
            var medicines = await _medicineRepository.ListAllAsync();
            return medicines;
        }

        public Task<Medicine> UpdateMedicineAsync(MedicineRequestDto MedicineRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
