using BloodBowlAPI.DTOs;
using BloodbowlData.Models;
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
                    Id = 1,
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
                    SkillCategoryId = 1
                }
            };
        }

        public static IEnumerable<SkillDTO> GetSkillDTOs()
        {
            return new SkillDTO[]{
                new SkillDTO()
                {
                    Id = 1,
                    Name = "Skill 1",
                    Icon = "Icon 1",
                    SkillCategoryId = 1,
                    SkillCategoryName = "Skill Category 1",
                    SkillCategoryShortName = 'S'
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
                    SkillCategoryId = 1,
                    SkillCategory = GetSkillCategories().First(c => c.Id == 1)
                }
            };
        }

        public static IEnumerable<SkillDTO> GetExampleSkillDTOs()
        {
            return new SkillDTO[]{
                new SkillDTO()
                {
                    Id = 2,
                    Name = "Skill 2",
                    Icon = "Icon 2",
                    SkillCategoryId = 1,
                    SkillCategoryName = "Skill Category 1",
                    SkillCategoryShortName = 'S'
                }
            };
        }
    }
}
