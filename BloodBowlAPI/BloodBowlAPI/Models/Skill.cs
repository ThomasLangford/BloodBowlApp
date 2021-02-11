using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodbowlAPI.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        
        public int SkillCategoryId { get; set; }

        public SkillCategory SkillCategory { get; set; }
        public List<StartingSkill> StartingSkills { get; set; }
    }
}
