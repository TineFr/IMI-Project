using Imi.Project.Api.Core.Entities;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _applicationUserRepository;
        private readonly ICageService _cageService;
        private readonly IBirdService _birdService;
        private readonly IMedicineService _medicineService;
        private readonly IPrescriptionService _prescriptionService;

        public UserService(IUserRepository applicationUserRepository, ICageService cageService, IBirdService birdService, IMedicineService medicineService, IPrescriptionService prescriptionService)
        {
            _applicationUserRepository = applicationUserRepository;
            _cageService = cageService;
            _birdService = birdService;
            _medicineService = medicineService;
            _prescriptionService = prescriptionService;
        }

        public async Task<ApplicationUserResponseDto> GetUserByIdAsync(Guid id)
        {
            var user = await _applicationUserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new BadRequestException($"User with id {id} does not exist");
            }
            ApplicationUserResponseDto result = user.MapToDto();
            return result;
        }


        public async Task<IEnumerable<ApplicationUser>> ListAllUsersAsync()
        {
            var ApplicationApplicationUserList = await _applicationUserRepository.ListAllAsync();
            return ApplicationApplicationUserList;
        }

        public async Task<ApplicationUserResponseDto> UpdateUserAsync(Guid id, ApplicationUserRequestDto dto)
        {
            var user = await _applicationUserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new BadRequestException($"User with id {id} does not exist");
            }
            var newUserEntity = dto.MapToEntity();
            var result = await _applicationUserRepository.AddAsync(newUserEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _applicationUserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new BadRequestException($"User with id {id} does not exist");
            }
            var cages = await _cageService.GetCagesByUserIdAsync(id);
            await _cageService.DeleteMultiple(cages.ToList());

            var birds = await _birdService.GetBirdsByUserIdAsync(id);
            await _birdService.DeleteMultiple(birds.ToList());

            var medicines = await _medicineService.GetMedicinesByUserIdAsync(id);
            await _medicineService.DeleteMultiple(medicines.ToList());

            var prescriptions = await _prescriptionService.GetPrescriptionsByUserIdAsync(id);
            await _prescriptionService.DeleteMultiple(prescriptions.ToList());

            await _applicationUserRepository.DeleteAsync(user);
        }

        public async Task<ApplicationUserResponseDto> AddUserAsync(ApplicationUserRequestDto dto)
        {
            var newUserEntity = dto.MapToEntity();
            var result = await _applicationUserRepository.AddAsync(newUserEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }
    }
}
