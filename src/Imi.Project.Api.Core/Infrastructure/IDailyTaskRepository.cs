using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Infrastructure
{
    public interface IDailyTaskRepository : IBaseRepository<DailyTask>
    {
        Task<IEnumerable<Bird>> GetByCageIdAsync(Guid id);
    }
}
