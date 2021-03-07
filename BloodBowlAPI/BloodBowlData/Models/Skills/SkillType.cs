using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Models.Skills
{
    public class SkillType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Enums.SkillType Id { get; set; }
        public string Description { get; set; }
        public bool IsAvailableToBuy { get; set; }
        public int? Cost { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
