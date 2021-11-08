using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class IdentityRoleSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>[]
                {
                  new IdentityRole<Guid>
                  {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Administrator",
                    NormalizedName = ("Administrator").ToUpper()
                   },
                  new IdentityRole<Guid>
                  {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "BaseUser",
                    NormalizedName = ("BaseUser").ToUpper()
                   }
                });

        }
    }
}
