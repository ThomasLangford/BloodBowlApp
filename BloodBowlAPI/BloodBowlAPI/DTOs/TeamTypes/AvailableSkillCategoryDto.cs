using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class AvailableSkillCategoryDto
    {
        public int Id { get; set; }
        [Required]
        public int SkillCategoryId { get; set; }
        public string SkillCategoryShortName { get; set; }
        public string SkillCategoryName { get; set; }
        [Required]
        public int LevelUpTypeId { get; set; }
        public string LevelUpTypeName { get; set; }
    }
}
