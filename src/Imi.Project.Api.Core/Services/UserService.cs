
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
        private readonly ICageRepository _cageRepository;

        public UserService(IUserRepository userRepository, ICageRepository cageRepository)
        {
            _userRepository = userRepository;
            _cageRepository = cageRepository;
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
            await _userRepository.DeleteAsync(user);  
        }

        public async Task<User> AddUserAsync(User user)
        {
            var result = await _userRepository.AddAsync(user);
            return result;
        }
    }
}
