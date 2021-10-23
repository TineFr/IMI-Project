﻿using Imi.Project.Api.Core.Dtos.Requests;
using Imi.Project.Api.Core.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> ListAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(Guid id);
        Task<UserResponseDto> AddUserAsync(UserRequestDto userRequestDto);
        Task<UserResponseDto> UpdateUserAsync(UserRequestDto userRequestDto);
        Task<IEnumerable<CageResponseDto>> GetCagesByUserIdAsync(Guid Id);
        Task DeleteUserAsync(UserRequestDto userRequestDto);

    }
}
