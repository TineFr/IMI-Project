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
    public class UserService : IUserService
    {
        private readonly IUserRepository _applicationUserRepository;
        private readonly ICageRepository _cageRepository;
        private readonly IBirdRepository _birdRepository;
        private readonly IMedicineRepository _medicineRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;

        public UserService(IUserRepository applicationUserRepository, 
                           ICageRepository cageRepository, 
                           IBirdRepository birdRepository,
                           IMedicineRepository medicineRepository, 
                           IPrescriptionRepository prescriptionRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _cageRepository = cageRepository;
            _birdRepository = birdRepository;
            _medicineRepository = medicineRepository;
            _prescriptionRepository = prescriptionRepository;
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


        public async Task<IEnumerable<ApplicationUserResponseDto>> ListAllUsersAsync(PaginationParameters parameters)
        {
            var users = await _applicationUserRepository.ListAllAsync();
            if (users.Count() == 0)
            {
                throw new ItemNotFoundException($"No users were found");
            }
            var usersPaginated = Pagination.AddPagination<ApplicationUser>(users, parameters);
            var result = usersPaginated.MapToDtoList();
            return result;
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
            var cages = await _cageRepository.GetByUserIdAsync(id);
            await _cageRepository.DeleteMultipleAsync(cages.ToList());

            var birds = await _birdRepository.GetByUserIdAsync(id);
            await _birdRepository.DeleteMultipleAsync(birds.ToList());

            var medicines = await _medicineRepository.GetByUserIdAsync(id);
            await _medicineRepository.DeleteMultipleAsync(medicines.ToList());

            var prescriptions = await _prescriptionRepository.GetByUserIdAsync(id);
            await _prescriptionRepository.DeleteMultipleAsync(prescriptions.ToList());

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
