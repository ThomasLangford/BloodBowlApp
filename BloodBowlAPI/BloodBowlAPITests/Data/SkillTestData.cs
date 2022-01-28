using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPITests.Mocks;
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
                    Name = $"{TestContants.TPREFIX}SKILL_1",
                    Description = $"{TestContants.TPREFIX}SKILL_1_DESCRIPTION",
                    //RuleSetId = 1,
                    //RulesetName =  $"{TestContants.TPREFIX}Blood Bowl 2",
                    //SkillCategoryId = 1,
                    //SkillCategoryName = $"{TestContants.TPREFIX}Skill Category 1",
                    //SkillCategoryShortName = $"{TestContants.TPREFIX}S",
                }
            };
        }

        public static IEnumerable<SkillCategoryDto.SkillCategorySkillDto> GetSimpleSkillDtos()
        {
            return new SkillCategoryDto.SkillCategorySkillDto[]{
                new SkillCategoryDto.SkillCategorySkillDto()
                {
                    Id = 1000,
                    Name = $"{TestContants.TPREFIX}SKILL_1",
                    Description = $"{TestContants.TPREFIX}SKILL_1_DESCRIPTION",
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
                    Name = $"{TestContants.TPREFIX}Skill Category 1",
                    ShortName = $"{TestContants.TPREFIX}S",
                    Skills = GetSimpleSkillDtos().ToList()
                }
            };
        }
    }
}
