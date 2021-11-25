
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Helper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Dtos.Users;


namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICageService _cageService;
        private readonly IBirdService _birdService;
        private readonly IMedicineService _medicineService;
        private readonly IPrescriptionService _prescriptionService;

        public UserService(IUserRepository userRepository, ICageService cageService, IBirdService birdService, IMedicineService medicineService, IPrescriptionService prescriptionService)
        {
            _userRepository = userRepository;
            _cageService = cageService;
            _birdService = birdService;
            _medicineService = medicineService;
            _prescriptionService = prescriptionService;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user= await _userRepository.GetByIdAsync(id);
            return user;
        }


        public async Task<IEnumerable<User>> ListAllUsersAsync()
        {
            var userList = await _userRepository.ListAllAsync();
            return userList;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var result = await _userRepository.UpdateAsync(user);
            return result;
        }

        public async Task DeleteUserAsync(User user)
        {
            var cages = await _cageService.GetCagesByUserIdAsync(user.Id);
            await _cageService.DeleteMultiple(cages.ToList());

            var birds = await _birdService.GetBirdsByUserIdAsync(user.Id);
            await _birdService.DeleteMultiple(birds.ToList());

            var medicines = await _medicineService.GetMedicinesByUserIdAsync(user.Id);
            await _medicineService.DeleteMultiple(medicines.ToList());

            var prescriptions = await _prescriptionService.GetPrescriptionsByUserIdAsync(user.Id);
            await _prescriptionService.DeleteMultiple(prescriptions.ToList());
            await _userRepository.DeleteAsync(user);  
        }

        public async Task<User> AddUserAsync(User user)
        {
            var result = await _userRepository.AddAsync(user);
            return result;
        }
    }
}
