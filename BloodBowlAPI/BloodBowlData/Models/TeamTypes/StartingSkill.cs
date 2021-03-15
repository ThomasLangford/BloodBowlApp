using BloodBowlData.Models.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlData.Models.TeamTypes
{
    [Table("PlayerTypeSkill")]
    public class StartingSkill
    {
        public int Id { get; set; }
        public int PlayerTypeId { get; set; }
        public PlayerType PlayerType { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
