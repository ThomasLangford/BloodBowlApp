using BloodBowlAPI.DTOs.Skills;
using BloodBowlData.Enums;
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
                    Id = SkillCategoryEnum.Strength,
                    Name = "Skill Category 1",
                    ShortName = 'S'
                }
            };
        }

        public static IEnumerable<Skill> GetSkills()
        {
            return new Skill[]{
                new Skill()
                {
                    Id = 1,
                    Name = "Skill 1",
                    Icon = "Icon 1",
                    SkillCategoryId = SkillCategoryEnum.Strength
                }
            };
        }

        public static IEnumerable<SkillDto> GetSkillDTOs()
        {
            return new SkillDto[]{
                new SkillDto()
                {
                    Id = 1,
                    Name = "Skill 1",
                    Icon = "Icon 1",
                    SkillCategoryId = 1,
                    SkillCategoryName = "Skill Category 1",
                    SkillCategoryShortName = 'S',
                    SkillTypeId = 1,
                    SkillTypeDescription = "Skill"
                }
            };
        }

        public static IEnumerable<Skill> GetExampleSkills()
        {
            return new Skill[]{
                new Skill()
                {
                    Id = 2,
                    Name = "Skill 2",
                    Icon = "Icon 2",
                    SkillCategoryId = BloodBowlData.Enums.SkillCategoryEnum.Strength,
                    SkillCategory = GetSkillCategories().First(c => c.Id == BloodBowlData.Enums.SkillCategoryEnum.Strength)
                }
            };
        }

        public static IEnumerable<SkillDto> GetExampleSkillDTOs()
        {
            return new SkillDto[]
            {
                new SkillDto()
                {
                    Id = 2,
                    Name = "Skill 2",
                    Icon = "Icon 2",
                    SkillCategoryId = 1,
                    SkillCategoryName = "Skill Category 1",
                    SkillCategoryShortName = 'S',
                    SkillTypeId = 1,
                    SkillTypeDescription = "Skill"
                }
            };
        }
    }
}
