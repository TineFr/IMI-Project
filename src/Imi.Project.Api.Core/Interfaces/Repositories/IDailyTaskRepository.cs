using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IDailyTaskRepository : IBaseRepository<DailyTask>
    {
        Task<IEnumerable<DailyTask>> GetByCageIdAsync(Guid id);
    }
}
