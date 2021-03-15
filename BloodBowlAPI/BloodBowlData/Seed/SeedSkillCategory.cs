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
                    InternalName = "General",
                    LocalizationName = "SkillCategory.Name.General",
                    LocalizationShortName = "SkillCategory.ShortName.General"
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Strength,
                    InternalName = "Strength",
                    LocalizationName = "SkillCategory.Name.Strength",
                    LocalizationShortName = "SkillCategory.ShortName.Strength"
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Passing,
                    InternalName = "Passing",
                    LocalizationName = "SkillCategory.Name.Passing",
                    LocalizationShortName = "SkillCategory.ShortName.Passing"
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Agility,
                    InternalName = "Agility",
                    LocalizationName = "SkillCategory.Name.Agility",
                    LocalizationShortName = "SkillCategory.ShortName.Agility"
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Mutation,
                    InternalName = "Mutation",
                    LocalizationName = "SkillCategory.Name.Mutation",
                    LocalizationShortName = "SkillCategory.ShortName.Mutation"
                },
                new SkillCategory
                {
                    Id = SkillCategoryEnum.Extraordinary,
                    InternalName = "Extraordinary",
                    LocalizationName = "SkillCategory.Name.Extraordinary",
                    LocalizationShortName = "SkillCategory.ShortName.Extraordinary"
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
