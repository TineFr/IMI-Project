using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Seeding
{
    public class UserSeeding
    {
       
        public static void Seeding(ModelBuilder modelBuilder)
        {
            IPasswordHasher<User> hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
               new User[]
               {
                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserName = "tine.franchois@gmail.com",
                        NormalizedUserName = ("tine.franchois@gmail.com").ToUpper(),
                        Email = "tine.franchois@gmail.com",
                        NormalizedEmail = ("tine.franchois@gmail.com").ToUpper(),
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserName = "deq.claire@gmail.com",
                        Email = "deq.claire@gmail.com",
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "%h!E*:25ty"),
                        NormalizedEmail = ("deq.claire@gmail.com").ToUpper(),
                        NormalizedUserName = ("deq.claire@gmail.com").ToUpper(),

                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserName = "depotter.sander@gmail.com",
                        Email = "depotter.sander@gmail.com",
                        EmailConfirmed = true,
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "=rR7fDevT6"),
                        NormalizedEmail = ("depotter.sander@gmail.com").ToUpper(),
                        NormalizedUserName = ("depotter.sander@gmail.com").ToUpper(),                      
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        UserName = "haenebalcke.niels@gmail.com",
                        Email = "haenebalcke.niels@gmail.com",
                        EmailConfirmed = true,
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "G)}7E2jMVz"),
                        NormalizedEmail = ("haenebalcke.niels@gmail.com").ToUpper(),
                        NormalizedUserName = ("haenebalcke.niels@gmail.com").ToUpper(),                      
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        UserName = "jochem.dewandel@gmail.com",
                        Email = "jochem.dewandel@gmail.com",
                        EmailConfirmed = true,
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "=Pcw4?:DQ]"),
                        NormalizedEmail = ("jochem.dewandel@gmail.com").ToUpper(),
                        NormalizedUserName = ("jochem.dewandel@gmail.com").ToUpper(),                      
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        UserName = "jonas.desmet@telenet.be",
                        Email = "jonas.desmet@telenet.be",
                        EmailConfirmed = true,
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "X>Na493Vhb"),
                        NormalizedEmail = ("jonas.desmet@telenet.be").ToUpper(),
                        NormalizedUserName = ("jonas.desmet@telenet.be").ToUpper(),                       
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        UserName = "niels.verbeke@hotmail.com",
                        Email = "niels.verbeke@hotmail.com",
                        EmailConfirmed = true,
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "zb3RLc}bW"),
                        NormalizedEmail = ("niels.verbeke@hotmail.com").ToUpper(),
                        NormalizedUserName = ("niels.verbeke@hotmail.com").ToUpper(),                       
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        UserName = "ann.meerpoel@skynet.be",
                        Email = "ann.meerpoel@skynet.be",
                        EmailConfirmed = true,
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "8~[;9A6nD="),
                        NormalizedEmail = ("ann.meerpoel@skynet.be").ToUpper(),
                        NormalizedUserName = ("ann.meerpoel@skynet.be").ToUpper(),                        
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        UserName = "lotens.jurgen@hotmail.com",
                        Email = "lotens.jurgen@hotmail.com",
                        EmailConfirmed = true,
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "wTZ2~-ndN"),
                        NormalizedEmail = ("lotens.jurgen@hotmail.com").ToUpper(),
                        NormalizedUserName = ("lotens.jurgen@hotmail.com").ToUpper(),                       
                    },


                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        UserName = "janne.jannes@gmail.com",
                        Email = "janne.jannes@gmail.com",
                        EmailConfirmed = true,
                        SecurityStamp =  Guid.NewGuid().ToString("D"),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                        PasswordHash = hasher.HashPassword(null, "UtyVmn8/NP"),
                        NormalizedEmail = ("janne.jannes@gmail.com").ToUpper(),
                        NormalizedUserName = ("janne.jannes@gmail.com").ToUpper(),                        
                    },
               }

              
               ); ;
        }
    }
}
