
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> ListAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(Guid id);
        Task<ApplicationUser> AddUserAsync(ApplicationUser user);
        Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);
        Task DeleteUserAsync(ApplicationUser user);

    }
}
