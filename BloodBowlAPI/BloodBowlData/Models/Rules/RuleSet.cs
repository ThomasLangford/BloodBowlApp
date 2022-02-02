using BloodBowlData.Enums;
using BloodBowlData.Models.Skills;
using BloodBowlData.Models.TeamTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Models.Rules
{
    public class Ruleset
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public RulesetEnum Id { get; set; }
        public string LocalizationName { get; set; }
        public bool Supported { get; set; } = false;
        public List<Skill> Skills { get; set; }
        public List<TeamType> TeamTypes { get; set; }
    }
}
