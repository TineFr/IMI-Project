using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<MedicineResponseDto> GetMedicineByIdAsync(Guid id)
        {
            var medicine = await _medicineRepository.GetByIdAsync(id);
            if (medicine == null)
            {
                throw new BadRequestException($"Medicine with id {id} does not exist");
            }
            MedicineResponseDto result = medicine.MapToDto();
            return result;
        }
        public async Task<IEnumerable<MedicineResponseDto>> ListAllMedicinesAsync(PaginationParameters parameters)
        {
            var medecines = await _medicineRepository.ListAllAsync();
            if (medecines.Count() == 0)
            {
                throw new ItemNotFoundException($"No medicines were found");
            }
            var medicinesPaginated = Pagination.AddPagination<Medicine>(medecines, parameters);
            var result = medicinesPaginated.MapToDtoList();
            return result;
        }
        public async Task<MedicineResponseDto> AddMedicineAsync(MedicineRequestDto dto)
        {
            await ValidateRequest(dto);
            var newBirdEntity = dto.MapToEntity();
            var result = await _medicineRepository.AddAsync(newBirdEntity);
            var resultDto = result.MapToDto();
            return resultDto;

        }
        public async Task<MedicineResponseDto> UpdateMedicineAsync(Guid id, MedicineRequestDto dto)
        {
            var medicine = await _medicineRepository.GetByIdAsync(id);
            if (medicine == null)
            {
                throw new BadRequestException($"Medicine with id {id} does not exist");
            }
            await ValidateRequest(dto);
            var updatedBirdEntity = medicine.Update(dto);
            var result = await _medicineRepository.UpdateAsync(updatedBirdEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }
        public async Task DeleteMedicineAsync(Guid id)
        {
            var bird = await _medicineRepository.GetByIdAsync(id);
            if (bird == null)
            {
                throw new BadRequestException($"Medicine with id {id} does not exist");
            }
            await _medicineRepository.DeleteAsync(bird);
        }
        public async Task DeleteMultiple(List<Medicine> medicines)
        {
            await _medicineRepository.DeleteMultipleAsync(medicines);
        }
        public async  Task<IEnumerable<MedicineResponseDto>> GetMedicinesByUserIdAsync(Guid id, PaginationParameters parameters)
        {
            if (await _medicineRepository.EntityExists<ApplicationUser>(id))
            {
                var medicines = await _medicineRepository.GetByUserIdAsync(id);
                if (medicines.Count() == 0)
                {
                    throw new ItemNotFoundException($"No medicines were found for user with id {id}");
                }
                var medicinesPaginated = Pagination.AddPagination<Medicine>(medicines, parameters);
                var result = medicinesPaginated.MapToDtoList();
                return result;
            }
            else throw new ItemNotFoundException($"User with id {id} does not exist");
        }
        private async Task ValidateRequest(MedicineRequestDto dto)
        {
            if (!(await _medicineRepository.EntityExists<ApplicationUser>(dto.UserId)))
            {
                throw new ItemNotFoundException($"User with id {dto.UserId} does not exist");
            }
        }
    }
}
