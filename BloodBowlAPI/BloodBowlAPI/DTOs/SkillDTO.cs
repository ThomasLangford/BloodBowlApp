﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs
{
    public class SkillDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int SkillCategoryId { get; set; }
        public int SkillCategoryName { get; set; }
        public int SkillCategoryShortName { get; set; }
    }
}
