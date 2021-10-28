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
        public async Task<IEnumerable<Medicine>> GetByUserIdAsync(Guid id)
        {
            return await GetAll().Where(m => m.UserId.Equals(id)).ToListAsync();
        }


    }
}
