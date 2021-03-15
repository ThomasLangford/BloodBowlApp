using BloodBowlData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class LevelUpTypeDto
    {
        public LevelUpTypeEnum Id { get; set; }
        public string Name { get; set; }
    }
}
