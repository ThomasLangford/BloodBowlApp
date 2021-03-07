using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class LevelUpTypeDto
    {
        public BloodBowlData.Enums.LevelUpType Id { get; set; }
        public string Description { get; set; }
    }
}
