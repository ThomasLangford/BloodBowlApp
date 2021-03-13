using BloodBowlAPI.Enums;
using BloodBowlAPI.Models.Rules;
using BloodBowlAPI.Models.TeamTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Models.Skills
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

        [Required]
        public SkillCategoryEnum SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }

        public List<StartingSkill> StartingSkills { get; set; }

        [Required]
        public RuleSetEnum RuleSetId { get; set; }
        public RuleSet RuleSet { get; set; }
    }
}
