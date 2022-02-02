using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.Validators;
using BloodBowlData.Models;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class PlayerTypeDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public int MaximumAllowedOnTeam { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Move { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Agility { get; set; }
        [Required]
        public int ArmourValue { get; set; }
        [Required]
        [UniqueSkillDtoCollectionValidator]
        public List<SkillDto> StartingSkills { get; set; }
        [Required]
        [UniqueAvailableSkillCategoryCollectionValidator]
        public List<AvailableSkillCategoryDto> AvailableSkillCategories { get; set; }
    }
}
