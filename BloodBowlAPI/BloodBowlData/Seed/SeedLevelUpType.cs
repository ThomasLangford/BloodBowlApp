using BloodBowlAPI.Enums;
using BloodBowlAPI.Models;
using BloodBowlAPI.Models.Skills;
using BloodBowlAPI.Models.TeamTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPI.Seed
{
    public static class SeedLevelUpType
    {
        public static List<LevelUpType> GetSeed()
        {
            return new List<LevelUpType>
            {
                new LevelUpType
                {
                    Id = LevelUpTypeEnum.Normal,
                    Name = "Normal"
                },
                new LevelUpType
                {
                    Id = LevelUpTypeEnum.Double,
                    Name = "Doubles"
                },
            };
        }
    }
}
