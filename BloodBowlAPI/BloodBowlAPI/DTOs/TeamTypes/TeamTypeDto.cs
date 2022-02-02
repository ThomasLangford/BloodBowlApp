using BloodBowlAPI.DTOs.Skills;
using BloodBowlData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class TeamTypeDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public int RerollCost { get; set; }
        [Required]
        public bool Apothicary { get; set; }
        [Required]
        public bool Necromancer { get; set; }
        
        public List<PlayerTypeDto> PlayerTypes { get; set; }

        [Required]
        public RulesetEnum RulesetId { get; set; }
    }
}
