using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Models.TeamTypes
{
    public class PlayerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumAllowedOnTeam { get; set; }
        public int Cost { get; set; }
        public int Move { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int ArmourValue { get; set; }

        public int TeamTypeId { get; set; }
        public TeamType TeamType { get; set; }
        public List<StartingSkill> StartingSkills { get; set; }
        public List<AvailableSkillCategory> AvailableSkillCategories { get; set; }
    }
}
