﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class TeamTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RerollCost { get; set; }
        public int RerollMaximumCount { get; set; }
        public bool Apothicary { get; set; }
        public List<PlayerTypeDto> PlayerTypes { get; set; }
    }
}
