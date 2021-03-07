using BloodBowlData.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models.TeamTypes
{
    public class PlayerLevelUpType
    {
        public int Id { get; set; }
        public int PlayerTypeId { get; set; }
        public PlayerType PlayerType { get; set; }
        public int SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public int LevelUpTypeId { get; set; }
        public LevelUpType LevelUpType { get; set; }
    }
}
