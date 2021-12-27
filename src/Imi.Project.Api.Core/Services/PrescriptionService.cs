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
    public class PrescriptionService : IPrescriptionService
    {
        protected readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }
        public async Task<PrescriptionResponseDto> GetPrescriptionByIdAsync(Guid id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id);
            if (prescription == null)
            {
                throw new BadRequestException($"Prescription with id {id} does not exist");
            }
            PrescriptionResponseDto result = prescription.MapToDto();
            return result;
        }
        public async Task<IEnumerable<PrescriptionResponseDto>> ListAllPrescriptionsAsync(PaginationParameters parameters)
        {
            var prescriptions = await _prescriptionRepository.ListAllAsync();
            if (prescriptions.Count() == 0)
            {
                throw new ItemNotFoundException($"No prescriptions were found");
            }
            var prescriptionsPaginated = Pagination.AddPagination<Prescription>(prescriptions, parameters);
            var result = prescriptionsPaginated.MapToDtoList();
            return result;
        }
        public async Task<PrescriptionResponseDto> AddPrescriptionAsync(PrescriptionRequestDto dto)
        {
            await ValidateRequest(dto);
            var newPrescriptionEntity = dto.MapToEntity();
            var result = await _prescriptionRepository.AddAsync(newPrescriptionEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }
        public async Task<PrescriptionResponseDto> UpdatePrescriptionAsync(Guid id, PrescriptionRequestDto dto)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id);
            if (prescription == null)
            {
                throw new BadRequestException($"Prescription with id {id} does not exist");
            }
            await ValidateRequest(dto);
            var updatedPrescriptionEntity = prescription.Update(dto);
            var result = await _prescriptionRepository.UpdateAsync(updatedPrescriptionEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }
        public async Task DeletePrescriptionAsync(Guid id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id);
            if (prescription == null)
            {
                throw new BadRequestException($"Prescription with id {id} does not exist");
            }
            await _prescriptionRepository.DeleteAsync(prescription);
        }
        public async Task DeleteMultiple(List<Prescription> prescriptions)
        {
            await _prescriptionRepository.DeleteMultipleAsync(prescriptions);
        }
        public async Task<IEnumerable<PrescriptionResponseDto>> GetPrescriptionsByUserIdAsync(Guid id, PaginationParameters parameters)
        {
            if (await _prescriptionRepository.EntityExists<ApplicationUser>(id))
            {
                var prescriptions = await _prescriptionRepository.GetByUserIdAsync(id);
                if (prescriptions.Count() == 0)
                {
                    throw new ItemNotFoundException($"No medicines were found for user with id {id}");
                }
                var prescriptionsPaginated = Pagination.AddPagination<Prescription>(prescriptions, parameters);
                var result = prescriptionsPaginated.MapToDtoList();
                return result;
            }
            else throw new ItemNotFoundException($"User with id {id} does not exist");
        }
        private async Task ValidateRequest(PrescriptionRequestDto dto)
        {
            if (!(await _prescriptionRepository.EntityExists<ApplicationUser>(dto.UserId)))
            {
                throw new ItemNotFoundException($"User with id {dto.UserId} does not exist");
            }
            if (!(await _prescriptionRepository.EntityExists<Medicine>(dto.Medicine)))
            {
                throw new ItemNotFoundException($"Medicine with id {dto.UserId} does not exist");
            }
            foreach (var id in dto.Birds)
            {
                if (!(await _prescriptionRepository.EntityExists<Bird>(id)))
                {
                    throw new ItemNotFoundException($"Bird with id {id} does not exist");
                }
            }
            if (dto.StartDate > dto.EndDate)
            {
                throw new BadRequestException($"Start date can not be greater than enddate");
            }
        }
    }
}
