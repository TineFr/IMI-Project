using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class CageRepository : BaseRepository<Cage>, ICageRepository
    {
        public CageRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Cage> GetAll()
        {
            return _dbContext.Cages.Include(c => c.User)
                                   .Include(c => c.DailyTasks)
                                   .Include(c => c.Birds)
                                   .ThenInclude(b => b.Species)
                                   .Include(c => c.Birds);
        }

        public async override Task<IEnumerable<Cage>> ListAllAsync()
        {
            return await GetAll().OrderBy(c => c.Name).ToListAsync();
        }
        public async override Task<Cage> GetByIdAsync(Guid id)
        {
            return await GetAll().SingleOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task<IEnumerable<Cage>> GetByUserIdAsync(Guid id)
        {
            var cages = await GetAll().Where(p => p.UserId.Equals(id)).OrderBy(c => c.Name).ToListAsync();
            return cages;
        }

        public async Task<Cage> ExsistsForUserId(Guid userId, Guid? id)
        {
            var cage = (await GetByUserIdAsync(userId)).ToList().FirstOrDefault(c => c.Id.Equals(id));
            return cage;
        }
    }
}
