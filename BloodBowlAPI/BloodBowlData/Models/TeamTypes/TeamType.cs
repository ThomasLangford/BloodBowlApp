using BloodBowlData.Enums;
using BloodBowlData.Models.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models.TeamTypes
{
    public class TeamType
    {
        public int Id { get; set; }
        public string InternalName { get; set; }
        public string LocalizationName { get; set; }
        public int RerollCost { get; set; }
        public bool Apothicary { get; set; }
        public bool Necromancer { get; set; }
        public List<PlayerType> PlayerTypes { get; set; }
        public RulesetEnum RuleSetId { get; set; }
        public Ruleset RuleSet { get; set; }
    }
}
