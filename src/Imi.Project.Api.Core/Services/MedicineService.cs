using Imi.Project.Api.Core.Dtos.Medicines;
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

        public Task<MedicineResponseDto> AddMedicineAsync(MedicineRequestDto MedicineRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMedicineAsync(MedicineRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<MedicineResponseDto> GetMedicineByIdAsync(Guid id)
        {
            var medicine = await _medicineRepository.GetByIdAsync(id);
            return medicine.MapToDto();
        }

        public async  Task<IEnumerable<MedicineResponseDto>> GetMedicinesByUserIdAsync(Guid id)
        {
            var medicines = await _medicineRepository.GetByUserIdAsync(id);
            return medicines.MapToDtoList();

        }

        public async Task<IEnumerable<MedicineResponseDto>> ListAllMedicinesAsync()
        {
            var medicines = await _medicineRepository.ListAllAsync();
            return medicines.MapToDtoList();
        }

        public Task<MedicineResponseDto> UpdateMedicineAsync(MedicineRequestDto MedicineRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
