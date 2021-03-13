using BloodBowlAPI.Models.Rules;
using System.Collections.Generic;

namespace BloodBowlAPI.Seed
{
    public static class SeedRuleSet
    {
        public static List<RuleSet> GetSeed()
        {
            return new List<RuleSet>
            {
                new RuleSet
                {
                    Id = Enums.RuleSetEnum.BloodBowl2,
                    Name = "Blood Bowl 2",
                    Supported = true
                },
                new RuleSet
                {
                    Id = Enums.RuleSetEnum.BloodBowl2020,
                    Name = "Blood Bowl Season 2 (2020)"
                },
            };
        }
    }
}
