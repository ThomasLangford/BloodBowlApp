using BloodBowlData.Enums;
using BloodBowlData.Models.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Models.Rules
{
    public class RuleSet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public RuleSetEnum Id { get; set; }
        public string Name { get; set; }
        public bool Supported { get; set; } = false;
        public List<Skill> Skills { get; set; }
        public List<SkillCategoryRuleSet> SkillCategoryRuleSet { get; set; }
    }
}
