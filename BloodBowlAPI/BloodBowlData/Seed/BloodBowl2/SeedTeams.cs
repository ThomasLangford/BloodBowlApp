using BloodBowlData.Enums;
using BloodBowlData.Models.TeamTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Seed.BloodBowl2
{
    static class SeedTeams
    {
        public static List<TeamType> SeedTeamTypes()
        {
            return new List<TeamType>
            {
                new TeamType
                {
                    Id = 1,
                    InternalName = "Humans",
                    LocalizationName = "TeamType.Name.Humans",
                    RerollCost = 50,
                    Apothicary = true,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
            };
        }

        public static List<PlayerType> SeedHumanTeamPlayerTypes()
        {
            return new List<PlayerType>
            {
                new PlayerType
                {
                    Id = 1,
                    TeamTypeId= 1,
                    InternalName = "Lineman",
                    LocalizationName = "PlayerType.Name.Lineman",
                    Cost = 50,
                    Move = 6,
                    Strength = 3,
                    Agility = 3,
                    ArmourValue = 8,
                    MaximumOnTeam = 16,
                },
                new PlayerType
                {
                    Id = 2,
                    TeamTypeId= 1,
                    InternalName = "Catcher",
                    LocalizationName = "PlayerType.Name.Catcher",
                    Cost = 70,
                    Move = 8,
                    Strength = 2,
                    Agility = 3,
                    ArmourValue = 8,
                    MaximumOnTeam = 4,
                },
                new PlayerType
                {
                    Id = 3,
                    TeamTypeId= 1,
                    InternalName = "Thrower",
                    LocalizationName = "PlayerType.Name.Thrower",
                    Cost = 70,
                    Move = 6,
                    Strength = 3,
                    Agility = 3,
                    ArmourValue = 8,
                    MaximumOnTeam = 2,
                },
                new PlayerType
                {
                    Id = 4,
                    TeamTypeId= 1,
                    InternalName = "Blitzer",
                    LocalizationName = "PlayerType.Name.Blitzer",
                    Cost = 90,
                    Move = 7,
                    Strength = 3,
                    Agility = 3,
                    ArmourValue = 8,
                    MaximumOnTeam = 4,
                },
                new PlayerType
                {
                    Id = 5,
                    TeamTypeId= 1,
                    InternalName = "Ogre",
                    LocalizationName = "PlayerType.Name.Ogre",
                    Cost = 140,
                    Move = 5,
                    Strength = 5,
                    Agility = 2,
                    ArmourValue = 9,
                    MaximumOnTeam = 1,
                },
            };
        }

        public static List<StartingSkill> SeedHumanTeamStartingSkills()
        {
            var players = SeedHumanTeamPlayerTypes();

            return new List<StartingSkill>
            {
                // Catcher
                new StartingSkill
                {
                    Id = 1,
                    PlayerTypeId = 2,
                    SkillId = (int)SkillBloodBowl2Enum.Dodge
                },
                new StartingSkill
                {
                    Id = 2,
                    PlayerTypeId = 2,
                    SkillId = (int)SkillBloodBowl2Enum.Catch
                },
                // Thrower
                new StartingSkill
                {
                    Id = 3,
                    PlayerTypeId = 3,
                    SkillId = (int)SkillBloodBowl2Enum.SureHands
                },
                new StartingSkill
                {
                    Id = 4,
                    PlayerTypeId = 3,
                    SkillId = (int)SkillBloodBowl2Enum.Pass
                },
                // Blitzer
                new StartingSkill
                {
                    Id = 5,
                    PlayerTypeId = 4,
                    SkillId = (int)SkillBloodBowl2Enum.Block
                },
                // Ogre
                new StartingSkill
                {
                    Id = 6,
                    PlayerTypeId = 5,
                    SkillId = (int)SkillBloodBowl2Enum.Loner
                },
                new StartingSkill
                {
                    Id = 7,
                    PlayerTypeId = 5,
                    SkillId = (int)SkillBloodBowl2Enum.ReallyStupid
                },
                new StartingSkill
                {
                    Id = 8,
                    PlayerTypeId = 5,
                    SkillId = (int)SkillBloodBowl2Enum.MightyBlow
                },
                new StartingSkill
                {
                    Id = 9,
                    PlayerTypeId = 5,
                    SkillId = (int)SkillBloodBowl2Enum.ThickSkull
                },
                new StartingSkill
                {
                    Id = 10,
                    PlayerTypeId = 5,
                    SkillId = (int)SkillBloodBowl2Enum.ThrowTeamMate
                },
            };
        }

        public static List<AvailableSkillCategory> SeedHumanTeamAvailableSkillCategories()
        {
            return new List<AvailableSkillCategory>
            {
                // Lineman
                new AvailableSkillCategory
                {
                    Id = 1,
                    PlayerTypeId = 1,
                    SkillCategoryId = SkillCategoryEnum.General,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                },
                new AvailableSkillCategory
                {
                    Id = 2,
                    PlayerTypeId = 1,
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 3,
                    PlayerTypeId = 1,
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 4,
                    PlayerTypeId = 1,
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                // Catcher
                new AvailableSkillCategory
                {
                    Id = 5,
                    PlayerTypeId = 2,
                    SkillCategoryId = SkillCategoryEnum.General,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                },
                new AvailableSkillCategory
                {
                    Id = 6,
                    PlayerTypeId = 2,
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                },
                new AvailableSkillCategory
                {
                    Id = 7,
                    PlayerTypeId = 2,
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 8,
                    PlayerTypeId = 2,
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                // Thrower
                new AvailableSkillCategory
                {
                    Id = 9,
                    PlayerTypeId = 3,
                    SkillCategoryId = SkillCategoryEnum.General,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                },
                new AvailableSkillCategory
                {
                    Id = 8,
                    PlayerTypeId = 3,
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 11,
                    PlayerTypeId = 3,
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                },
                new AvailableSkillCategory
                {
                    Id = 12,
                    PlayerTypeId = 3,
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                // Blitzer
                new AvailableSkillCategory
                {
                    Id = 13,
                    PlayerTypeId = 4,
                    SkillCategoryId = SkillCategoryEnum.General,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                },
                new AvailableSkillCategory
                {
                    Id = 14,
                    PlayerTypeId = 4,
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 15,
                    PlayerTypeId = 4,
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 16,
                    PlayerTypeId = 4,
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                },
                // Ogre
                new AvailableSkillCategory
                {
                    Id = 17,
                    PlayerTypeId = 5,
                    SkillCategoryId = SkillCategoryEnum.General,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 18,
                    PlayerTypeId = 5,
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 19,
                    PlayerTypeId = 5,
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    LevelUpTypeId = LevelUpTypeEnum.Double
                },
                new AvailableSkillCategory
                {
                    Id = 20,
                    PlayerTypeId = 5,
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    LevelUpTypeId = LevelUpTypeEnum.Normal
                },
            };
        }
    }
}
