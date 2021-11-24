using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class DailyTaskRepository : BaseRepository<DailyTask>, IDailyTaskRepository
    {
        public DailyTaskRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<DailyTask> GetAll()
        {
            return _dbContext.DailyTasks;
        }
        public async override Task<IEnumerable<DailyTask>> ListAllAsync()
        {
            return await GetAll().OrderBy(b => b.Description).ToListAsync();
        }
        public async override Task<DailyTask> GetByIdAsync(Guid id)
        {
            return await GetAll().SingleOrDefaultAsync(b => b.Id.Equals(id));
        }
        public async Task<IEnumerable<DailyTask>> GetByCageIdAsync(Guid id)
        {
            return await GetAll().Where(b => b.CageId.Equals(id)).ToListAsync();
        }

 
    }
}
