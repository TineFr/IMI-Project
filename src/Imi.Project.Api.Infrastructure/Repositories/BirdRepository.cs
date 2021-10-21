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
    public class BirdRepository : BaseRepository<Bird>, IBirdRepository
    {
        public BirdRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Bird> GetAll()
        {
            return _dbContext.Birds.Include(b => b.User)
                                   .Include(b => b.Cage)
                                   .Include(b => b.Species);                         
        }

        public async Task<IEnumerable<Bird>> GetByCageIdAsync(Guid id)
        {
            return await GetAll().Where(b => b.CageId.Equals(id)).ToListAsync();
        }

        public async Task<IEnumerable<Bird>> GetByUserIdAsync(Guid id)
        {
            return await GetAll().Where(b => b.UserId.Equals(id)).ToListAsync();
        }
    }
}
