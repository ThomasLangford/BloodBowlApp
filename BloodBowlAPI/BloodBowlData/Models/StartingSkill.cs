using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodbowlData.Models
{
    public class StartingSkill
    {
        public int Id { get; set; }
        public int PlayerTypeId { get; set; }
        public PlayerType PlayerType { get; set; }
        public int SkillId {get; set;}
        public Skill Skill { get; set; }
    }
}
