using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure
{
    public class MyAviaryDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<BirdPrescription> BirdPrescriptions { get; set; }

        public MyAviaryDbContext(DbContextOptions<MyAviaryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IdentityRoleSeeding.Seeding(modelBuilder);
            ApplicationUserSeeding.Seeding(modelBuilder);
            IdentityUserRoleSeeding.Seeding(modelBuilder);
            DailyTasksSeeding.Seeding(modelBuilder);
            CageSeeding.Seeding(modelBuilder);
            SpeciesSeeding.Seeding(modelBuilder);
            BirdSeeding.Seeding(modelBuilder);
            MedicineSeeding.Seeding(modelBuilder);
            PrescriptionSeeding.Seeding(modelBuilder);
            BirdPrescriptionSeeding.Seeding(modelBuilder);

            modelBuilder
                .Entity<BirdPrescription>()
                .ToTable(nameof(BirdPrescriptions))
                .HasKey(bm => new { bm.BirdId, bm.PrescriptionId });

            modelBuilder.Entity<Cage>()
                 .HasKey(c => c.Id);
            modelBuilder.Entity<Prescription>()
                 .HasKey(c => c.Id);
            //modelBuilder.Entity<ApplicationUser>()
            //      .HasKey(c => c.Id);
            modelBuilder.Entity<Bird>()
                  .HasKey(c => c.Id);
            modelBuilder.Entity<Medicine>()
                  .HasKey(c => c.Id);
            modelBuilder.Entity<DailyTask>()
                  .HasKey(c => c.Id);
            modelBuilder.Entity<Species>()
                  .HasKey(c => c.Id);

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

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Birds)
                .WithOne(e => e.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Medicines)
                .WithOne(e => e.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Cages)
                .WithOne(e => e.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }


    }
}
