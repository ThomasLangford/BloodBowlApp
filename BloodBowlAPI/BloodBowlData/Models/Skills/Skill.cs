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
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Icon { get; set; }

        [Required]
        public Enums.SkillType SKillTypeId { get; set; }
        public SkillType SkillType { get; set; }

        [Required]
        public Enums.SkillCategory SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }

        public List<StartingSkill> StartingSkills { get; set; }
    }
}
