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

        public async Task<Medicine> AddMedicineAsync(Medicine medicine)
        {
            var result = await _medicineRepository.AddAsync(medicine);
            return result;
          
        }

        public async Task DeleteMedicineAsync(Medicine medicine)
        {
           await _medicineRepository.DeleteAsync(medicine);

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

        public async Task<Medicine> UpdateMedicineAsync(Medicine medicine)
        {
            var result = await _medicineRepository.UpdateAsync(medicine);
            return result;
        }
    }
}
