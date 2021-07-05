using BloodBowlData.Enums;
using BloodBowlData.Models.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.Data
{
    class RulesetTestData
    {
        public static IEnumerable<Ruleset> GetRuleSets()
        {
            return new Ruleset[]
            {
                new Ruleset()
                {
                    Id = RulesetEnum.BloodBowl2,
                    LocalizationName = "Blood Bowl 2"
                },
                new Ruleset()
                {
                    Id = RulesetEnum.BloodBowl3,
                    LocalizationName = "Blood Bowl 3"
                },
                new Ruleset()
                {
                    Id = RulesetEnum.BloodBowl2020,
                    LocalizationName = "Blood Bowl 2020"
                }
            };
        }
    }
}
