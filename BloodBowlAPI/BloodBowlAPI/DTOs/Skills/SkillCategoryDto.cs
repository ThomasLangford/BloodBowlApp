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
        public string ShortName { get; set; }
        public string Name { get; set; }

        public List<SkillDtoSimple> Skills { get; set; }
    }
}
