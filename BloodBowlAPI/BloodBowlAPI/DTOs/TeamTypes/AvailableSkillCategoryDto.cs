using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class AvailableSkillCategoryDto
    {
        public int Id { get; set; }

        public int SkillCategoryId { get; set; }
        public char SkillCategoryShortName { get; set; }
        public string SkillCategoryName { get; set; }

        public int LevelUpTypeId { get; set; }
        public string LevelUpTypeName { get; set; }
    }
}
