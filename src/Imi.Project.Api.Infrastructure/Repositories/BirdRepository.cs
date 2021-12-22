using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class BirdRepository : BaseRepository<Bird>, IBirdRepository

    {
        public BirdRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Bird> GetAll()
        {
            return _dbContext.Birds.Include(b => b.User)
                                   .Include(b => b.Cage)
                                   .ThenInclude(b => b.Birds)
                                   .Include(b => b.Species)
                                   .Include(b => b.BirdPrescriptions)
                                   .ThenInclude(b => b.Prescription);
        }
        public async override Task<IEnumerable<Bird>> ListAllAsync()
        {
            return await GetAll().OrderBy(b => b.Name).ToListAsync();
        }
        public async override Task<Bird> GetByIdAsync(Guid id)
        {
            return await GetAll().SingleOrDefaultAsync(b => b.Id.Equals(id));
        }
        public async Task<IEnumerable<Bird>> GetByCageIdAsync(Guid id)
        {
            return await GetAll().Where(b => b.CageId.Equals(id)).OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<IEnumerable<Bird>> GetByUserIdAsync(Guid id)
        {
            return await GetAll().Where(b => b.UserId.Equals(id)).OrderBy(b => b.Name).ToListAsync();
        }




    }
}
