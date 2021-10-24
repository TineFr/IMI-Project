using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface ICageRepository : IBaseRepository<Cage>
    {
        Task<IEnumerable<Cage>> GetCagesByUserIdAsync(Guid id);

        //Task<Cage> GetCageByUserIdAsync(Guid userId, Guid cageId);
    }
}
