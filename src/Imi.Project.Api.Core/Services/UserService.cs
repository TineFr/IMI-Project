using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _ApplicationUserRepository;
        private readonly ICageService _cageService;
        private readonly IBirdService _birdService;
        private readonly IMedicineService _medicineService;
        private readonly IPrescriptionService _prescriptionService;

        public UserService(IUserRepository ApplicationUserRepository, ICageService cageService, IBirdService birdService, IMedicineService medicineService, IPrescriptionService prescriptionService)
        {
            _ApplicationUserRepository = ApplicationUserRepository;
            _cageService = cageService;
            _birdService = birdService;
            _medicineService = medicineService;
            _prescriptionService = prescriptionService;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(Guid id)
        {
            var ApplicationApplicationUser = await _ApplicationUserRepository.GetByIdAsync(id);
            return ApplicationApplicationUser;
        }


        public async Task<IEnumerable<ApplicationUser>> ListAllUsersAsync()
        {
            var ApplicationApplicationUserList = await _ApplicationUserRepository.ListAllAsync();
            return ApplicationApplicationUserList;
        }

        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
        {
            var result = await _ApplicationUserRepository.UpdateAsync(user);
            return result;
        }

        public async Task DeleteUserAsync(ApplicationUser user)
        {
            var cages = await _cageService.GetCagesByUserIdAsync(user.Id);
            await _cageService.DeleteMultiple(cages.ToList());

            var birds = await _birdService.GetBirdsByUserIdAsync(user.Id);
            await _birdService.DeleteMultiple(birds.ToList());

            var medicines = await _medicineService.GetMedicinesByUserIdAsync(user.Id);
            await _medicineService.DeleteMultiple(medicines.ToList());

            var prescriptions = await _prescriptionService.GetPrescriptionsByUserIdAsync(user.Id);
            await _prescriptionService.DeleteMultiple(prescriptions.ToList());
            await _ApplicationUserRepository.DeleteAsync(user);
        }

        public async Task<ApplicationUser> AddUserAsync(ApplicationUser user)
        {
            var result = await _ApplicationUserRepository.AddAsync(user);
            return result;
        }
    }
}
