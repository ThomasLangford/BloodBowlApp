using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class LevelUpTypeDto
    {
        public BloodBowlAPI.Enums.LevelUpTypeEnum Id { get; set; }
        public string Name { get; set; }
    }
}
