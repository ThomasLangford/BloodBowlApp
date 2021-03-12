using BloodBowlData.Models.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
