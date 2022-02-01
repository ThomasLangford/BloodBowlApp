using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlAPITests.Mocks;
using BloodBowlData.Enums;
using BloodBowlData.Models.Skills;
using BloodBowlData.Models.TeamTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPITests.Data
{
    class TeamTypeTestData
    {
        public static IEnumerable<TeamType> GetTeamTypes()
        {
            return new List<TeamType>
            {
                new TeamType
                {
                    Id = 1000,
                    Name = "Test Team",
                    Apothicary = true,
                    Necromancer = false,
                    RerollCost = 50,
                    RuleSetId = RulesetEnum.BloodBowl2
                }
            };
        }

        public static IEnumerable<PlayerType> GetPlayerTypes()
        {
            return new List<PlayerType>
            {
                new PlayerType
                {
                    Id = 1000,
                    TeamTypeId = 1000,
                    Name = "Test Player",
                    Agility = 1,
                    ArmourValue = 2,
                    Move = 3,
                    Strength = 4,
                    Cost = 5000,
                    MaximumAllowedOnTeam = 10,
                }
            };
        }

        public static IEnumerable<StartingSkill> GetStartingSkills()
        {
            return new List<StartingSkill>
            {
                new StartingSkill
                {
                    Id = 1000,
                    PlayerTypeId = 1000,
                    SkillId = 1000
                }
            };
        }

        public static IEnumerable<AvailableSkillCategory> GetAvailableSkillCategories()
        {
            return new List<AvailableSkillCategory>
            {
                new AvailableSkillCategory
                {
                    Id = 1000,
                    PlayerTypeId = 1000,
                    SkillCategoryId = SkillCategoryEnum.General,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                }
            };
        }

        public static IEnumerable<LevelUpType> GetLevelUpTypes()
        {
            return new List<LevelUpType>
            {
                new LevelUpType
                {
                    Id = LevelUpTypeEnum.Normal,
                    LocalizationName = "Normal"
                }
            };
        }

        public static IEnumerable<SkillCategory> GetSkillCategories()
        {
            return new SkillCategory[]
            {
                new SkillCategory()
                {
                    Id = SkillCategoryEnum.General,
                    LocalizationName = "General",
                    LocalizationShortName = "G"
                }
            };
        }

        public static IEnumerable<Skill> GetSkills()
        {
            return new Skill[]{
                new Skill()
                {
                    Id = 1000,
                    InternalName = "Skill1",
                    LocalizationName = "SKILL_1",
                    LocalizationDescription = "SKILL_1_DESCRIPTION",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RulesetEnum.BloodBowl2
                },
                new Skill()
                {
                    Id = 1001,
                    InternalName = "Skill1",
                    LocalizationName = "SKILL_2",
                    LocalizationDescription = "SKILL_2_DESCRIPTION",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RulesetEnum.BloodBowl2020
                }
            };
        }

        public static List<TeamTypeDto> GetTeamTypeDtos()
        {
            return new List<TeamTypeDto>() { GetTeamTypeDto() };
        }

        public static TeamTypeDto GetTeamTypeDto()
        {
            return new TeamTypeDto
            {
                Id = 1000,
                Name = TestContants.TRANSLATION_PREFIX + "Test Team",
                Apothicary = true,
                Necromancer = false,
                RerollCost = 50,
                RulesetId = RulesetEnum.BloodBowl2,
                PlayerTypes = new List<PlayerTypeDto> { GetPlayerTypeDto() },
            };
        }

        private static PlayerTypeDto GetPlayerTypeDto()
        {
            return new PlayerTypeDto()
            {
                Id = 1000,
                Agility = 1,
                ArmourValue = 2,
                Cost = 5000,
                MaximumAllowedOnTeam = 10,
                Move = 3,
                Strength = 4,
                Name = TestContants.TRANSLATION_PREFIX + "Test Player",
                StartingSkills = new List<SkillDto> 
                {
                    new SkillDto
                    {
                        Description = TestContants.TRANSLATION_PREFIX +"SKILL_1_DESCRIPTION",
                        Id = 1000,
                        Name = TestContants.TRANSLATION_PREFIX + "SKILL_1",
                        SkillCategory = null
                    }
                },
                AvailableSkillCategories = new List<AvailableSkillCategoryDto>
                {
                    new AvailableSkillCategoryDto
                    {
                        Id = 1000,
                        LevelUpTypeId = 1,
                        LevelUpTypeName = null,
                        SkillCategoryId = 1,
                        SkillCategoryName = null,
                        SkillCategoryShortName = null
                    }
                }
            };
        }
    }
}
