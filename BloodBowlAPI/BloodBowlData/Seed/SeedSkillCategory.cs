using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBowlData.Enums;
using BloodBowlData.Models.Skills;

namespace BloodBowlData.Seed
{
    public static class SeedSkillCategory
    {
        public static List<SkillCategory> GetSeed()
        {
            return new List<SkillCategory>
            {
                new SkillCategory
                {
                    Id = SkillCategoryEnum.General,
                    Name = "General",
                    ShortName = 'G'                    
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Strength,
                    Name = "Strength",
                    ShortName = 'S'
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Passing,
                    Name = "Passing",
                    ShortName = 'P'
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Agility,
                    Name = "Agility",
                    ShortName = 'A'
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Extraordinary,
                    Name = "Extraordinary",
                    ShortName = 'E'
                },
            };
        }

        public static List<SkillCategoryRuleSet> GetSeedSkillCategoryRuleSet()
        {
            return new List<SkillCategoryRuleSet>
            {
                new SkillCategoryRuleSet
                {
                    Id = 1,
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new SkillCategoryRuleSet
                {
                    Id = 2,
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new SkillCategoryRuleSet
                {
                    Id = 3,
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new SkillCategoryRuleSet
                {
                    Id = 4,
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new SkillCategoryRuleSet
                {
                    Id = 5,
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                }
            };
        }
    }
}
