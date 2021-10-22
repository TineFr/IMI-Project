using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class CageRepository : BaseRepository<Cage>, ICageRepository
    {
        public CageRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Cage> GetAll()
        {
            return _dbContext.Cages.Include(c => c.User)
                                   .Include(c => c.DailyTasks)
                                   .Include(c => c.Birds);
                                   
        }

        public async override Task<IEnumerable<Cage>> ListAllAsync()
        {
            return await GetAll().ToListAsync();
        }
        public async override Task<Cage> GetByIdAsync(Guid id)
        {
            return await GetAll().SingleOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task<IEnumerable<Cage>> GetByUserIdAsync(Guid id)
        {
            return await GetAll().Where(c => c.UserId.Equals(id)).ToListAsync();
        }
    }
}
