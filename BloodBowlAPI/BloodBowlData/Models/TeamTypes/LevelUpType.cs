using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Models.TeamTypes
{
    public class LevelUpType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Enums.LevelUpTypeEnum Id { get; set; }
        public string Name { get; set; }

        public List<AvailableSkillCategory> AvailableSkillCategories { get; set; }
    }
}
