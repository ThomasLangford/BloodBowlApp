using BloodBowlData.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Models.Rules
{
    public class RuleSet
    {
        public Enums.RuleSetEnum Id { get; set; }
        public string Name { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
