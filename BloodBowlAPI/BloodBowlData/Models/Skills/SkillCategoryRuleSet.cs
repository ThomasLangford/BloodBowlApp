using BloodBowlData.Enums;
using BloodBowlData.Models.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Models.Skills
{
    public class SkillCategoryRuleSet
    {
        public int Id { get; set; }
        public SkillCategoryEnum SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public RuleSetEnum RuleSetId { get; set; }
        public RuleSet RuleSet { get; set; }
    }
}
