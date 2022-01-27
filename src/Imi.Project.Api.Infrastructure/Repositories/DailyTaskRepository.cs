using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class DailyTaskRepository : BaseRepository<DailyTask>, IDailyTaskRepository
    {
        public DailyTaskRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<DailyTask>> GetByCageIdAsync(Guid id)
        {
            return await GetAll().Where(b => b.CageId.Equals(id)).ToListAsync();
        }


    }
}
