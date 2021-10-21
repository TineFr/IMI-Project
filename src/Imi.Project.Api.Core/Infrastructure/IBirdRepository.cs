using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Infrastructure
{
    interface IBirdRepository : IBaseRepository<Bird>
    {
        Task<IEnumerable<Bird>> GetByUserIdAsync(Guid id);
        Task<IEnumerable<Bird>> GetByCageIdAsync(Guid id);
    }
}
