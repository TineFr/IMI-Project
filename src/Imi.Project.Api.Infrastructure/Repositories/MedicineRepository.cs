using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Medicine> GetAll()
        {
            return _dbContext.Medicine.Include(b => b.User)
                                      .Include(b => b.Prescriptions)
                                      .ThenInclude(b => b.BirdPrescriptions);

        }
        public async override Task<IEnumerable<Medicine>> ListAllAsync()
        {
            return await GetAll().OrderBy(b => b.Name).ToListAsync();
        }
        public async override Task<Medicine> GetByIdAsync(Guid id)
        {
            return await GetAll().SingleOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task<IEnumerable<Medicine>> GetByUserIdAsync(Guid id)
        {
            return await GetAll().Where(m => m.UserId.Equals(id)).OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<Medicine> ExsistsForUserId(Guid userId, Guid id)
        {
            var medicine = (await GetByUserIdAsync(userId)).ToList().FirstOrDefault(c => c.Id.Equals(id));
            return medicine;
        }

    }
}
