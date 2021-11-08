using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class IdentityUserRoleSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>[]
                {

                    //admin
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    //baseuser
                     new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                     new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000006")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000008")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000009")
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000010")
                    }
                });

        }
        
    }
}
