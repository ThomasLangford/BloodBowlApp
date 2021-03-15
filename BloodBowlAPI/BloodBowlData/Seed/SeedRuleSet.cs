using BloodBowlData.Enums;
using BloodBowlData.Models.Rules;
using System.Collections.Generic;

namespace BloodBowlData.Seed
{
    public static class SeedRuleSet
    {
        public static List<RuleSet> GetSeed()
        {
            return new List<RuleSet>
            {
                new RuleSet
                {
                    Id = RuleSetEnum.BloodBowl2,
                    Name = "Blood Bowl 2",
                    Supported = true
                },
                new RuleSet
                {
                    Id = RuleSetEnum.BloodBowl2020,
                    Name = "Blood Bowl Season 2 (2020)"
                },
            };
        }
    }
}
