﻿using BloodBowlAPI.DTOs.Skills;
using System;
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
        public bool Necromancer { get; set; }
        public List<TeamTypePlayerTypeDto> PlayerTypes { get; set; }

        public int RulesetId { get; set; }
        public string RulesetName { get; set; }

        public class TeamTypePlayerTypeDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int MaximumAllowedOnTeam { get; set; }
            public int Cost { get; set; }
            public int Move { get; set; }
            public int Strength { get; set; }
            public int Agility { get; set; }
            public int ArmourValue { get; set; }

            public List<TeamTypePlayerTypeStartingSkillDto> StartingSkills { get; set; }
            public List<TeamTypePlayerTypeAvailableSkillCategoryDto> AvailableSkillCategories { get; set; }
        }

        public class TeamTypePlayerTypeStartingSkillDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class TeamTypePlayerTypeAvailableSkillCategoryDto
        {
            public int Id { get; set; }

            public int SkillCategoryId { get; set; }
            public string SkillCategoryShortName { get; set; }
            public string SkillCategoryName { get; set; }

            public int LevelUpTypeId { get; set; }
            public string LevelUpTypeName { get; set; }
        }
    }
}
