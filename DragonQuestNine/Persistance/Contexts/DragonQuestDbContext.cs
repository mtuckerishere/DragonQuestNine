using DragonQuestNine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Persistance.Contexts
{
    public class DragonQuestDbContext : DbContext
    {
        public DragonQuestDbContext(DbContextOptions<DragonQuestDbContext> options) : base(options) {}
       
        public virtual DbSet<Accolade> Accolades { get; set; }
        public virtual DbSet<AccoladeCategory> AccoladeCategories {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccoladeCategory>().ToTable("AccoladeCategories");
            modelBuilder.Entity<AccoladeCategory>().HasKey(ac => ac.Id);
            modelBuilder.Entity<AccoladeCategory>().Property(ac => ac.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<AccoladeCategory>().Property(ac => ac.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<AccoladeCategory>().HasMany(a => a.Accolades).WithOne(ac => ac.AccoladeCategory).HasForeignKey(a => a.AccoladeCategoryId);

            modelBuilder.Entity<Accolade>().ToTable("Accolades");
            modelBuilder.Entity<Accolade>().HasKey(a => a.Id);
            modelBuilder.Entity<Accolade>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Accolade>().Property(a => a.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Accolade>().Property(a => a.IsObtained).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<Accolade>().Property(a => a.DateObtained).HasDefaultValue(null);
        }
    }
}
