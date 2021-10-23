using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class SpeciesRepository : BaseRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
