using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.Enums;
using BloodBowlAPI.Models.Rules;
using BloodBowlAPI.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.Data
{
    class SkillTestData
    {
        public static IEnumerable<RuleSet> GetRuleSets()
        {
            return new RuleSet[]
            {
                new RuleSet()
                {
                    Id = RuleSetEnum.BloodBowl2,
                    Name = "Blood Bowl 2"
                }
            };
        }

        public static IEnumerable<SkillCategory> GetSkillCategories()
        {
            return new SkillCategory[]
            {
                new SkillCategory()
                {
                    Id = SkillCategoryEnum.General,
                    LocalizationName = "Skill Category 1",
                    LocalizationShortName = "S"
                }
            };
        }

        public static IEnumerable<Skill> GetSkills()
        {
            return new Skill[]{
                new Skill()
                {
                    Id = 1000,
                    InternalName = "Skill1",
                    LocalizationName = "SKILL_1",
                    LocalizationDescription = "SKILL_1_DESCRIPTION",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                }
            };
        }

        public static IEnumerable<SkillDto> GetSkillDTOs()
        {
            return new SkillDto[]{
                new SkillDto()
                {
                    Id = 1000,
                    InternalName = "Skill1",
                    Name = "$T$_SKILL_1",
                    Description = "$T$_SKILL_1_DESCRIPTION",
                    RuleSetId = 1,
                    RuleSetName =  "Blood Bowl 2",
                    SkillCategoryId = 1,
                    SkillCategoryName = "$T$_Skill Category 1",
                    SkillCategoryShortName = "$T$_S",
                }
            };
        }
    }
}
