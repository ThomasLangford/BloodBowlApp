using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodbowlData.Models
{
    public class LevelUpType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<AvailableSkillCategory> AvailableSkillCategories { get; set; }
    }
}
