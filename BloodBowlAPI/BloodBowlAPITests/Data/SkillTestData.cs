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
        public static IEnumerable<Skill> GetModels()
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

        public static IEnumerable<SkillDTO> GetDTOs()
        {
            return new SkillDTO[]{
                new SkillDTO()
                {
                    Id = 1,
                    Name = "Skill 1",
                    Icon = "Icon 1",
                    SkillCategory = new SkillCategoryDTO()
                    {
                        Id = 1,
                        Name = "Skill Category 1"
                    }
                }
            };
        }
    }
}
