using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBowlData.Enums;
using BloodBowlData.Models.Skills;

namespace BloodBowlData.Seed
{
    static class SeedSkillCategory
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
    }
}
