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
        protected readonly IMedicineRepository _medicineRepository;
        protected readonly IBirdRepository _birdRepository;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository,
                                   IMedicineRepository medicineRepository, 
                                   IBirdRepository birdRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _medicineRepository = medicineRepository;
            _birdRepository = birdRepository;
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
        public async Task<IEnumerable<PrescriptionResponseDto>> ListAllPrescriptionsAsync()
        {
            var prescriptions = await _prescriptionRepository.ListAllAsync();
            if (prescriptions.Count() == 0)
            {
                throw new ItemNotFoundException($"No prescriptions were found");
            }
            var result = prescriptions.MapToDtoList();
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
        public async Task<IEnumerable<PrescriptionResponseDto>> GetPrescriptionsByUserIdAsync(Guid id)
        {
            if (await _prescriptionRepository.EntityExists<ApplicationUser>(id))
            {
                var prescriptions = await _prescriptionRepository.GetByUserIdAsync(id);
                if (prescriptions.Count() == 0)
                {
                    throw new ItemNotFoundException($"No medicines were found for user with id {id}");
                }
                var result = prescriptions.MapToDtoList();
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
            var medecine = await _medicineRepository.ExsistsForUserId(dto.UserId, dto.Medicine);
            if (medecine == null)
            {
                throw new ItemNotFoundException($"Medicine with id {dto.Medicine} does not exist for this user");
            }
            foreach (var id in dto.Birds)
            {
                var bird = await _birdRepository.ExsistsForUserId(dto.UserId, id);
                if (bird == null)
                {
                    throw new ItemNotFoundException($"Bird with id {id} does not exist for this user");
                }
            }
            if (dto.StartDate.Date > dto.EndDate.Date)
            {
                throw new BadRequestException($"Start date can not be greater than enddate");
            }
        }

        public async Task<IEnumerable<PrescriptionResponseDto>> GetFilteredPrescriptionsFromUser(Guid userId, string query)
        {
            if (await _prescriptionRepository.EntityExists<ApplicationUser>(userId))
            {
                IEnumerable<Prescription> prescriptions = await _prescriptionRepository.GetByUserIdAsync(userId);
                if (prescriptions.Count() == 0)
                {
                    throw new ItemNotFoundException($"No cages were found");
                }
                if (!String.IsNullOrEmpty(query))
                {
                    List<Prescription> results = new List<Prescription>();
                    results.AddRange(prescriptions.Where(b => b.Medicine.Name.ToLower().Contains(query.ToLower())));
                    if (results.Count == 0)
                    {
                        throw new ItemNotFoundException($"No prescriptions were found");
                    }
                    else prescriptions = results;
                }
                var result = prescriptions.MapToDtoList();
                return result;
            }
            else throw new ItemNotFoundException($"User with id {userId} does not exist");
        }
    }
}
