using BloodBowlAPI.Models.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPI.Models.Skills
{
    public class SkillCategoryRuleSet
    {
        public int Id { get; set; }
        public Enums.SkillCategoryEnum SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public Enums.RuleSetEnum RuleSetId { get; set; }
        public RuleSet RuleSet { get; set; }
    }
}
