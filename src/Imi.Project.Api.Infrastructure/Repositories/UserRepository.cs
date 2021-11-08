using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Imi.Project.Api.Core.Interfaces.Repositories;
namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<ApplicationUser> GetAll()
        {
            return _dbContext.Users.Include(u => u.Cages)
                                   .ThenInclude(c => c.DailyTasks)
                                   .Include(u => u.Birds)
                                   .ThenInclude(b => b.Species)
                                   .Include(u => u.Medicines)
                                   .Include(u => u.Prescriptions)
                                   .ThenInclude(u => u.BirdPrescriptions);
        }

        public async override Task<IEnumerable<ApplicationUser>> ListAllAsync()
        {
            return await GetAll().OrderBy(u  => u.Name).ToListAsync();
        }

        public async override Task<ApplicationUser> GetByIdAsync(Guid id)
        {
            return await GetAll().SingleOrDefaultAsync(u => u.Id.Equals(id));
        }
    }
}
