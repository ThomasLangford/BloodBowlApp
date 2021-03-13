using BloodBowlAPI.DTOs.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.Skills
{
    public class SkillCategoryDto
    {
        public BloodBowlAPI.Enums.SkillCategoryEnum Id { get; set; }
        public char ShortName { get; set; }
        public string Name { get; set; }

        public List<SkillDto> Skills { get; set; }
    }
}
