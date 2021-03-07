using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBowlData.Models.Skills;

namespace BloodBowlData.Seed
{
    static class SeedSkillTypes
    {
        public static List<SkillType> GetSeed()
        {
            return new List<SkillType>
            {
                new SkillType
                {
                    Id = Enums.SkillType.Skill,
                    Description = "Skill",
                    IsAvailableToBuy = true,
                    Cost = 10
                },
                new SkillType
                {
                    Id = Enums.SkillType.ExtraordinarySkill,
                    Description = "Extraordinary Skill",
                    IsAvailableToBuy = false
                },
                new SkillType
                {
                    Id = Enums.SkillType.MinorAttribute,
                    Description = "Minor Stat-up",
                    IsAvailableToBuy = true,
                    Cost = 30
                },
                new SkillType
                {
                    Id = Enums.SkillType.MediumAttribute,
                    Description = "Medium Stat-up",
                    IsAvailableToBuy = true,
                    Cost = 40
                },
                new SkillType
                {
                    Id = Enums.SkillType.MajorAttribute,
                    Description = "Major Stat-up",
                    IsAvailableToBuy = true,
                    Cost = 50
                },
            };
        }
    }
}
