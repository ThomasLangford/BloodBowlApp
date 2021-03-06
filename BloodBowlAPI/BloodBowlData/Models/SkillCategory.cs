﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models
{
    public class SkillCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Enums.SkillCategory Id { get; set; }
        public char ShortName { get; set; }
        public string Name { get; set; }
        
        public List<Skill> Skills { get; set; }
        public List<PlayerLevelUpType> AvailableSkillCategories { get; set; }
    }
}
