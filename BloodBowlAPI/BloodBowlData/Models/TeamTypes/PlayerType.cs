using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models.TeamTypes
{
    public class PlayerType
    {
        public int Id { get; set; }
        public string InternalName { get; set; }
        public string LocalizationName { get; set; }
        public int MaximumOnTeam { get; set; }
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
