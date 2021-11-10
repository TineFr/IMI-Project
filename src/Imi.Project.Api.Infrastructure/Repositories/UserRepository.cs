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
    public class UserRepository : IUserRepository

       
    {
        protected readonly MyAviaryDbContext _dbContext;

        public UserRepository(MyAviaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMultipleAsync(List<ApplicationUser> users)
        {
            _dbContext.Users.RemoveRange(users);
            await _dbContext.SaveChangesAsync();

        }
        public IQueryable<ApplicationUser> GetAll()
        {
            return _dbContext.Users.Include(u => u.Cages)
                                   .ThenInclude(c => c.DailyTasks)
                                   .Include(u => u.Birds)
                                   .ThenInclude(b => b.Species)
                                   .Include(u => u.Medicines)
                                   .Include(u => u.Prescriptions)
                                   .ThenInclude(u => u.BirdPrescriptions);
        }

        public async Task<ApplicationUser> GetByIdAsync(Guid id)
        {
             return await GetAll().SingleOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async  Task<IEnumerable<ApplicationUser>> ListAllAsync()
        {
            return await GetAll().OrderBy(u => u.UserName).ToListAsync();
        }
        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
