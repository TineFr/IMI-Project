using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }
        public override IQueryable<Prescription> GetAll()
        {
            var prescriptions =    _dbContext.Prescriptions.Include(p => p.User)
                                                           .Include(p => p.BirdPrescriptions)
                                                           .ThenInclude(p => p.Bird)
                                                           .ThenInclude(b => b.Cage)
                                                           .Include(p => p.Medicine);
            return prescriptions;

        }
        public async override Task<Prescription> GetByIdAsync(Guid id)
        {
            return await GetAll().SingleOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task<IEnumerable<Prescription>> GetByUserIdAsync(Guid id)
        {
            return await GetAll().Where(b => b.UserId.Equals(id)).ToListAsync();
        }

        public async override Task<IEnumerable<Prescription>> ListAllAsync()
        {
            return await GetAll().OrderBy(b => b.StartDate).ToListAsync();
        }


    }
}
