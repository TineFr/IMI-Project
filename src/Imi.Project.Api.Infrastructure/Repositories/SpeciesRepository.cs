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
    public class SpeciesRepository : BaseRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(MyAviaryDbContext dbContext) : base(dbContext)
        {

        }

        public async override Task<IEnumerable<Species>> ListAllAsync()
        {
            return await GetAll().OrderBy(s => s.Name).ToListAsync();
        }
    }

}
