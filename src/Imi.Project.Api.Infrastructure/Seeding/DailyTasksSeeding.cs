using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class DailyTasksSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {

                modelBuilder.Entity<DailyTask>().HasData(
                    new DailyTask[]
                    {
                        new DailyTask
                        {
                            Id = Guid.Parse("DC063E36-6A74-429D-9569-97838A06EDE7"),
                            Name = "Refill water",
                            CageId = Guid.Parse("ABA63D5F-8DD1-42E3-93B8-898C71554E5A"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("2FB04232-9775-4EF8-BB2D-CC1C0296E84C"),
                            Name = "Clean branches",
                            CageId = Guid.Parse("ABA63D5F-8DD1-42E3-93B8-898C71554E5A"),
                            IsDone = true
                        },
                    }

                    );
            }
    }
}
