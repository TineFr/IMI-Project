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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<User> GetAll()
        {
            return _dbContext.Users.Include(u => u.Cages)
                                   .ThenInclude(c => c.DailyTasks)
                                   .Include(u => u.Birds)
                                   .ThenInclude(b => b.Species)
                                   .Include(u => u.Medicines);
        }

        public async override Task<IEnumerable<User>> ListAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async override Task<User> GetByIdAsync(Guid id)
        {
            return await GetAll().SingleOrDefaultAsync(u => u.Id.Equals(id));
        }
    }
}
