using Imi.Project.Api.Core.Dtos.Responses;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Helper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto> GetUserByIdAsync(Guid id)
        {
            var user= await _userRepository.GetByIdAsync(id);
            return user.MaptoDto();
        }

        public async Task<IEnumerable<UserResponseDto>> ListAllUsersAsync()
        {
            var userList = await _userRepository.ListAllAsync();
            return userList.MaptoDtoList();
        }
    }
}
