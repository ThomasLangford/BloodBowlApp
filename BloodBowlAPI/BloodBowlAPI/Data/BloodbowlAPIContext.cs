using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodbowlAPI.Models;

namespace BloodbowlAPI.Data
{
    public class BloodBowlAPIContext : DbContext
    {
        public BloodBowlAPIContext (DbContextOptions<BloodBowlAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TeamType> TeamType { get; set; }
        public DbSet<PlayerType> PlayerType { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<AvailableSkillCategory> AvailableSkillCategory { get; set; }
        public DbSet<LevelUpType> LevelUpType { get; set; }
        public DbSet<SkillCategory> SkillCategory { get; set; }
        public DbSet<StartingSkill> StartiingSkill { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //#warning To protect potentially sensitive information in your connection string, 
        //    //you should move it out of source code.See http://go.microsoft.com/fwlink/?LinkId=723263 
        //    //for guidance on storing connection strings.

        //    optionsBuilder.UseMySQL("server=localhost;database=bloodbowl;user=APICRUD;password=APICRUD");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(e => e.PlayerTypes);
            });

            modelBuilder.Entity<PlayerType>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }


        
    }
}
