using BloodBowlAPI.DTOs.Skills;
using BloodBowlData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.Skills
{
    public class SkillCategoryDto
    {
        public SkillCategoryEnum Id { get; set; }
        public char ShortName { get; set; }
        public string Name { get; set; }

        public List<SkillDto> Skills { get; set; }
    }
}
