using BloodBowlData.Enums;
using BloodBowlData.Models.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models.TeamTypes
{
    public class AvailableSkillCategory
    {
        public int Id { get; set; }
        public int PlayerTypeId { get; set; }
        public PlayerType PlayerType { get; set; }
        public SkillCategoryEnum SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public LevelUpTypeEnum LevelUpTypeId { get; set; }
        public LevelUpType LevelUpType { get; set; }
    }
}
