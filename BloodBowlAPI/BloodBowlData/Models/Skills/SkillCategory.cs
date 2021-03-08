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
        public Enums.SkillCategoryEnum Id { get; set; }
        public char ShortName { get; set; }
        public string Name { get; set; }

        public List<Skill> Skills { get; set; }
        public List<AvailableSkillCategory> AvailableSkillCategories { get; set; }
    }
}
