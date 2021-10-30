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
            return await GetAll().Where(m => m.UserId.Equals(id)).ToListAsync();
        }

        //public async Task<IEnumerable<Medicine>> GetByBirdIdAsync(Guid id)
        //{
        //    var birdmedicines = await _dbContext.BirdMedicines.Include(bm => bm.Medicine)
        //                                                      .Where(b => b.BirdId.Equals(id))
        //                                                      .ToListAsync();
        //    var medicines = birdmedicines.Select(bm => bm.Medicine);
        //    return medicines;


        //}



    }
}
