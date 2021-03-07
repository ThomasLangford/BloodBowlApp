using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models.TeamTypes
{
    public class LevelUpType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Enums.LevelUpType Id { get; set; }
        public string Description { get; set; }

        public List<PlayerLevelUpType> AvailableSkillCategories { get; set; }
    }
}
