using BloodBowlData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Seed
{
    static class SeedLevelUpType
    {
        public static List<LevelUpType> GetSeed()
        {
            return new List<LevelUpType>
            {
                new LevelUpType
                {
                    Id = Enums.LevelUpType.Normal,
                    Description = "Normal"
                },
                new LevelUpType
                {
                    Id = Enums.LevelUpType.Double,
                    Description = "Doubles"
                },
            };
        }
    }
}
