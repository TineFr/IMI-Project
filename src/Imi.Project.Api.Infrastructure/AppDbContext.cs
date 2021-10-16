using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<Nest> Nests { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserSeeding.Seeding(modelBuilder);
            DailyTasksSeeding.Seeding(modelBuilder);
            CageSeeding.Seeding(modelBuilder);
            SpeciesSeeding.Seeding(modelBuilder);
            FoodSeeding.Seeding(modelBuilder);
            BirdSeeding.Seeding(modelBuilder);
            PairSeeding.Seeding(modelBuilder);
            NestSeeding.Seeding(modelBuilder);
            //base.OnModelCreating(modelBuilder);
        }


    }
}
