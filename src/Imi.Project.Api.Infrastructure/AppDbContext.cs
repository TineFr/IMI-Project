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
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
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
            BirdSeeding.Seeding(modelBuilder);
            MedicineSeeding.Seeding(modelBuilder);
            BirdMedicineSeeding.Seeding(modelBuilder);

            modelBuilder
                .Entity<BirdMedicines>()
                .ToTable("BirdMedicine") 
                .HasKey(bm => new { bm.BirdId, bm.MedicineId });

            modelBuilder.Entity<Cage>()
                .HasMany(e => e.Birds)
                .WithOne(e => e.Cage)
                .HasForeignKey(p => p.CageId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Cage>()
                .HasMany(e => e.DailyTasks)
                .WithOne(e => e.Cage)
                .HasForeignKey(p => p.CageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Species>()
                .HasMany(e => e.Birds)
                .WithOne(e => e.Species)
                .HasForeignKey(p => p.SpeciesId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Birds)
                .WithOne(e => e.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Medicines)
                .WithOne(e => e.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Cages)
                .WithOne(e => e.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }


    }
}
