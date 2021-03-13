using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.Models;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class PlayerTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumAllowedOnTeam { get; set; }
        public int Cost { get; set; }
        public int Move { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int ArmourValue { get; set; }

        public List<SkillDto> StartingSkills { get; set; }
        public List<AvailableSkillCategoryDto> AvailableSkillCategories { get; set; }
    }
}
