using BloodBowlData.Enums;
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
        public LevelUpTypeEnum Id { get; set; }
        public string LocalizationName { get; set; }

        public List<AvailableSkillCategory> AvailableSkillCategories { get; set; }
    }
}
