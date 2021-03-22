using BloodBowlData.Enums;
using BloodBowlData.Models.TeamTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models.Skills
{
    public class SkillCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public SkillCategoryEnum Id { get; set; }

        public string InternalName { get; set; }
        public string LocalizationShortName { get; set; }
        public string LocalizationName { get; set; }

        public List<Skill> Skills { get; set; }
        public List<AvailableSkillCategory> AvailableSkillCategories { get; set; }
    }
}
