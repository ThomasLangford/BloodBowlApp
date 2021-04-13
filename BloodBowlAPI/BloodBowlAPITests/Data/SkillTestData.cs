using BloodBowlAPI.DTOs.Skills;
using BloodBowlData.Enums;
using BloodBowlData.Models.Rules;
using BloodBowlData.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.Data
{
    class SkillTestData
    {
        public static IEnumerable<Ruleset> GetRuleSets()
        {
            return new Ruleset[]
            {
                new Ruleset()
                {
                    Id = RulesetEnum.BloodBowl2,
                    LocalizationName = "Blood Bowl 2"
                },
                new Ruleset()
                {
                    Id = RulesetEnum.BloodBowl3,
                    LocalizationName = "Blood Bowl 3"
                },
                new Ruleset()
                {
                    Id = RulesetEnum.BloodBowl2020,
                    LocalizationName = "Blood Bowl 2020"
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
                    RuleSetId = RulesetEnum.BloodBowl2
                },
                new Skill()
                {
                    Id = 1001,
                    InternalName = "Skill1",
                    LocalizationName = "SKILL_2",
                    LocalizationDescription = "SKILL_2_DESCRIPTION",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RulesetEnum.BloodBowl2020
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
                    RulesetName =  "$T$_Blood Bowl 2",
                    SkillCategoryId = 1,
                    SkillCategoryName = "$T$_Skill Category 1",
                    SkillCategoryShortName = "$T$_S",
                }
            };
        }

        public static IEnumerable<SkillDtoSimple> GetSimpleSkillDtos()
        {
            return new SkillDtoSimple[]{
                new SkillDtoSimple()
                {
                    Id = 1000,
                    InternalName = "Skill1",
                    Name = "$T$_SKILL_1",
                    Description = "$T$_SKILL_1_DESCRIPTION",
                }
            };
        }

        public static IEnumerable<SkillCategoryDto> GetSkillCategoryDTOs()
        {
            return new SkillCategoryDto[]
            {
                new SkillCategoryDto()
                {
                    Id = SkillCategoryEnum.General,
                    Name = "$T$_Skill Category 1",
                    ShortName = "$T$_S",
                    Skills = GetSimpleSkillDtos().ToList()
                }
            };
        }
    }
}
