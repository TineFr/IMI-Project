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
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                            Description = "Add food",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                            Description = "Add food",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                            IsDone = true
                        },

                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                            Description = "Add food",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                            IsDone = false
                        },

                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                            IsDone = true
                        },

                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                            Description = "Clean branches",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                            Description = "Add food",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                            IsDone = false
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000023"),
                            Description = "Add food",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                            IsDone = true
                        },
                        new DailyTask
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000024"),
                            Description = "Refill water",
                            CageId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                            IsDone = false
                        },
                    }

                    );
            }
    }
}
