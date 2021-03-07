using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.Skills
{
    public class PlayerTypeLevelUpTypeDto
    {
        public int Id { get; set; }
        public int PlayerTypeId { get; set; }
        public int SkillCategoryId { get; set; }
        public string SkillCategoryShortName { get; set; }
        public string SkillCategoryName { get; set; }

        public int LevelUpTypeId { get; set; }
        public int LevelUpTypeName { get; set; }
    }
}
