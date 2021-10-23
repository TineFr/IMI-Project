using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class DailyTaskRepository : BaseRepository<DailyTask>, IDailyTaskRepository
    {
        public DailyTaskRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
