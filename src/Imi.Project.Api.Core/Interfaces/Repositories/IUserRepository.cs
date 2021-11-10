using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IUserRepository 
    {
        IQueryable<ApplicationUser> GetAll();
        Task<IEnumerable<ApplicationUser>> ListAllAsync();
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user);
        Task<ApplicationUser> AddAsync(ApplicationUser user);
        Task DeleteAsync(ApplicationUser user);
        Task DeleteMultipleAsync(List<ApplicationUser> users);
    }
}
