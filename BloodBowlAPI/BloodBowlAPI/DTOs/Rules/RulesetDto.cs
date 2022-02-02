using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.Rules
{
    public class RulesetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Supported { get; set; }
    }
}
