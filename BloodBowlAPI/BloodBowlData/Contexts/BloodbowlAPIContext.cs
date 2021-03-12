using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodBowlData.Seed;
using BloodBowlData.Models.TeamTypes;
using BloodBowlData.Models.Skills;
using BloodBowlData.Models.Rules;

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
        public virtual DbSet<SkillCategoryRuleSet> SkillCategoryRuleSet { get; set; }
        public virtual DbSet<StartingSkill> StartingSkill { get; set; }        
        public virtual DbSet<RuleSet> RuleSet { get; set; }

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

            if (!DoNotSeedData)
            {
                modelBuilder.Entity<RuleSet>().HasData(SeedRuleSet.GetSeed());
                modelBuilder.Entity<SkillCategory>().HasData(SeedSkillCategory.GetSeed());
                modelBuilder.Entity<SkillCategoryRuleSet>().HasData(SeedSkillCategory.SeedSkillCategoryRuleSet());
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
