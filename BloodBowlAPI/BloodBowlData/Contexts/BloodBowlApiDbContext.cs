using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodBowlData.Seed.BloodBowl2;
using BloodBowlData.Models.Rules;
using BloodBowlData.Models.Skills;
using BloodBowlData.Models.TeamTypes;
using BloodBowlData.Seed;

namespace BloodBowlData.Contexts
{
    public class BloodBowlApiDbContext : DbContext
    {
        public BloodBowlApiDbContext(DbContextOptions<BloodBowlApiDbContext> options)
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
        public virtual DbSet<Ruleset> Ruleset { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //
        //    #warning To protect potentially sensitive information in your connection string, 
        //    you should move it out of source code.See http://go.microsoft.com/fwlink/?LinkId=723263 
        //    For guidance on storing connection strings.
        //    Example:
        //    optionsBuilder.UseMySQL("server=localhost;database=bloodbowl;user=APICRUD;password=APICRUD");
        //

        public bool DoNotSeedData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Manually add delete triggers for RuleSet to stop cyclic cascade deletes
            modelBuilder
                .Entity<Skill>()
                .HasOne(e => e.RuleSet)
                .WithMany(e => e.Skills)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
                .Entity<TeamType>()
                .HasOne(e => e.RuleSet)
                .WithMany(e => e.TeamTypes)
                .OnDelete(DeleteBehavior.ClientCascade);

            if (!DoNotSeedData)
            {
                modelBuilder.Entity<Ruleset>().HasData(SeedRuleset.GetSeed());
                modelBuilder.Entity<SkillCategory>().HasData(SeedSkillCategory.GetSeed());
                modelBuilder.Entity<Skill>().HasData(SeedSkill.SeedSkills());

                modelBuilder.Entity<LevelUpType>().HasData(SeedLevelUpType.GetSeed());
            }
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
