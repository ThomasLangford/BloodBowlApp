using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs
{
    public class SkillCategoryDTO
    {
        public int Id { get; set; }
        public char ShortName { get; set; }
        public string Name { get; set; }

        public List<SkillDTO> Skills { get; set; }
    }
}
