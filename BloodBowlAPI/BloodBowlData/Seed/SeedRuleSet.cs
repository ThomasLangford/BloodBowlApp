using BloodBowlData.Enums;
using BloodBowlData.Models.Rules;
using System.Collections.Generic;

namespace BloodBowlData.Seed
{
    public static class SeedRuleset
    {
        public static List<Ruleset> GetSeed()
        {
            return new List<Ruleset>
            {
                new Ruleset
                {
                    Id = RulesetEnum.BloodBowl2,
                    LocalizationName = "Ruleset.Name.BloodBowl2",
                    Supported = true
                },
                new Ruleset
                {
                    Id = RulesetEnum.BloodBowl3,
                    LocalizationName = "Ruleset.Name.BloodBowl3",
                    Supported = true
                },
                new Ruleset
                {
                    Id = RulesetEnum.BloodBowl2020,
                    LocalizationName = "Ruleset.Name.BloodBowlSeason2"
                },
            };
        }
    }
}
