using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface ICageRepository : IBaseRepository<Cage>
    {
        Task<IEnumerable<Cage>> GetByUserIdAsync(Guid id);

        Task<Cage> ExsistsForUserId(Guid userId, Guid id);
    }
}
