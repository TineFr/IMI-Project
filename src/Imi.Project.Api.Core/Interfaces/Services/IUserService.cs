using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUserResponseDto>> ListAllUsersAsync(PaginationParameters parameters);
        Task<ApplicationUserResponseDto> GetUserByIdAsync(Guid id);
        Task<ApplicationUserResponseDto> AddUserAsync(ApplicationUserRequestDto user);
        Task<ApplicationUserResponseDto> UpdateUserAsync(Guid id, ApplicationUserRequestDto user);
        Task DeleteUserAsync(Guid id);

    }
}
