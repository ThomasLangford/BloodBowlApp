using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodBowlData.Seed;
using BloodBowlData.Models.TeamTypes;
using BloodBowlData.Models.Skills;

namespace BloodBowlData.Contexts
{
    public class BloodBowlAPIContext : DbContext
    {
        public BloodBowlAPIContext(DbContextOptions<BloodBowlAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TeamType> TeamType { get; set; }
        public virtual DbSet<PlayerType> PlayerType { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<AvailableSkillCategory> AvailableSkillCategory { get; set; }
        public virtual DbSet<LevelUpType> LevelUpType { get; set; }
        public virtual DbSet<SkillCategory> SkillCategory { get; set; }
        public virtual DbSet<StartingSkill> StartingSkill { get; set; }
        public virtual DbSet<SkillType> SkillType { get; set; }

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

            modelBuilder.Entity<SkillType>().HasData(SeedSkillTypes.GetSeed());
            modelBuilder.Entity<LevelUpType>().HasData(SeedLevelUpType.GetSeed());
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public virtual void SetState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }
    }
}
