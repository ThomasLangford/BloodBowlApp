using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodbowlData.Models
{
    public class Skill
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Icon { get; set; }

        [Required]
        public int SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }

        public List<StartingSkill> StartingSkills { get; set; }
    }
}
