using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodbowlAPI.Models
{
    public class SkillCategory
    {
        public int Id { get; set; }
        public char ShortName { get; set; }
        public string Name { get; set; }
        
        public List<Skill> Skills { get; set; }
        public List<AvailableSkillCategory> AvailableSkillCategories { get; set; }
    }
}
