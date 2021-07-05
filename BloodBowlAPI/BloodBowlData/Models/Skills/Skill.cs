using BloodBowlData.Enums;
using BloodBowlData.Models.Rules;
using BloodBowlData.Models.TeamTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models.Skills
{
    public class Skill
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string InternalName { get; set; }

        [Required]
        [MaxLength(500)]
        public string LocalizationName { get; set; }

        [Required]
        [MaxLength(500)]
        public string LocalizationDescription { get; set; }

        public SkillCategoryEnum SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }

        public List<StartingSkill> StartingSkills { get; set; }


        public RulesetEnum RuleSetId { get; set; }
        public Ruleset RuleSet { get; set; }
    }
}
