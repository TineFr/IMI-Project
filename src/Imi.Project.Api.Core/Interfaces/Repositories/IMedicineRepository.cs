using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IMedicineRepository : IBaseRepository<Medicine>
    {
        Task<IEnumerable<Medicine>> GetByUserIdAsync(Guid id);
    }
}
