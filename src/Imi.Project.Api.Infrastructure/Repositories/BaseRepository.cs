﻿using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MyAviaryDbContext _dbContext;

        public BaseRepository(MyAviaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteMultipleAsync(List<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();

        }

        public virtual IQueryable<T> GetAll()
        {
           return  _dbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await  _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));
            return entity;
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await  _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
