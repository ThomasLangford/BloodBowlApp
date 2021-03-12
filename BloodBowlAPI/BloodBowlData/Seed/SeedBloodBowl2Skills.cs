using BloodBowlData.Models.Skills;
using BloodBowlData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Seed
{
    public static class SeedBloodBowl2Skills
    {
        public static List<Skill> SeedSkills()
        {
            var skills = new List<Skill>(75);

            skills.AddRange(SeedGeneralSkills());
            skills.AddRange(SeedAgilitySkills());
            skills.AddRange(SeedPassingSkills());
            skills.AddRange(SeedStrengthSkills());
            skills.AddRange(SeedMutationSkills());
            skills.AddRange(SeedExtraordinarySkills());

            return skills;
        }
        public static List<Skill> SeedGeneralSkills()
        {
            return new List<Skill>
            {
                new Skill
                {
                    Id = 1,
                    InternalName = "Block",
                    LocalisationName = "SKILL_NAME_BLOCK",
                    LocalisationDescription = "SKILL_DESCRIPTION_BLOCK",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 2,
                    InternalName = "Dauntless",
                    LocalisationName = "SKILL_NAME_DAUNTLESS",
                    LocalisationDescription = "SKILL_DESCRIPTION_DAUNTLESS",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 3,
                    InternalName = "DirtyPlayer",
                    LocalisationName = "SKILL_NAME_DIRTYPLAYER",
                    LocalisationDescription = "SKILL_DESCRIPTION_DIRTYPLAYER",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 4,
                    InternalName = "Fend",
                    LocalisationName = "SKILL_NAME_FEND",
                    LocalisationDescription = "SKILL_DESCRIPTION_FEND",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 5,
                    InternalName = "Frenzy",
                    LocalisationName = "SKILL_NAME_FRENZY",
                    LocalisationDescription = "SKILL_DESCRIPTION_FRENZY",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 6,
                    InternalName = "Kick",
                    LocalisationName = "SKILL_NAME_KICK",
                    LocalisationDescription = "SKILL_DESCRIPTION_KICK",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 7,
                    InternalName = "KickOffReturn",
                    LocalisationName = "SKILL_NAME_KICKOFFRETURN",
                    LocalisationDescription = "SKILL_DESCRIPTION_KICKOFFRETURN",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 8,
                    InternalName = "PassBlock",
                    LocalisationName = "SKILL_NAME_PASSBLOCK",
                    LocalisationDescription = "SKILL_DESCRIPTION_PASSBLOCK",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 9,
                    InternalName = "Pro",
                    LocalisationName = "SKILL_NAME_PRO",
                    LocalisationDescription = "SKILL_DESCRIPTION_PRO",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 10,
                    InternalName = "Shadowing",
                    LocalisationName = "SKILL_NAME_SHADOWING",
                    LocalisationDescription = "SKILL_DESCRIPTION_SHADOWING",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 11,
                    InternalName = "StripBall",
                    LocalisationName = "SKILL_NAME_STRIPBALL",
                    LocalisationDescription = "SKILL_DESCRIPTION_STRIPBALL",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 12,
                    InternalName = "SureHands",
                    LocalisationName = "SKILL_NAME_SUREHANDS",
                    LocalisationDescription = "SKILL_DESCRIPTION_SUREHANDS",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 13,
                    InternalName = "Tackle",
                    LocalisationName = "SKILL_NAME_TACKLE",
                    LocalisationDescription = "SKILL_DESCRIPTION_TACKLE",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 14,
                    InternalName = "Wrestle",
                    LocalisationName = "SKILL_NAME_WRESTLE",
                    LocalisationDescription = "SKILL_DESCRIPTION_WRESTLE",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
            };
        }
        public static List<Skill> SeedAgilitySkills()
        {
            return new List<Skill>
            {
                new Skill
                {
                    Id = 15,
                    InternalName = "Catch",
                    LocalisationName = "SKILL_NAME_CATCH",
                    LocalisationDescription = "SKILL_DESCRIPTION_CATCH",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 16,
                    InternalName = "DivingCatch",
                    LocalisationName = "SKILL_NAME_DIVINGCATCH",
                    LocalisationDescription = "SKILL_DESCRIPTION_DIVINGCATCH",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 17,
                    InternalName = "DivingTackle",
                    LocalisationName = "SKILL_NAME_DIVINGTACKLE",
                    LocalisationDescription = "SKILL_DESCRIPTION_DIVINGTACKLE",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 18,
                    InternalName = "Dodge",
                    LocalisationName = "SKILL_NAME_DODGE",
                    LocalisationDescription = "SKILL_DESCRIPTION_DODGE",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 19,
                    InternalName = "JumpUp",
                    LocalisationName = "SKILL_NAME_JUMPUP",
                    LocalisationDescription = "SKILL_DESCRIPTION_JUMPUP",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 20,
                    InternalName = "Leap",
                    LocalisationName = "SKILL_NAME_LEAP",
                    LocalisationDescription = "SKILL_DESCRIPTION_LEAP",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 21,
                    InternalName = "SideStep",
                    LocalisationName = "SKILL_NAME_SIDESTEP",
                    LocalisationDescription = "SKILL_DESCRIPTION_SIDESTEP",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 22,
                    InternalName = "SneakyGit",
                    LocalisationName = "SKILL_NAME_SNEAKYGIT",
                    LocalisationDescription = "SKILL_DESCRIPTION_SNEAKYGIT",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 23,
                    InternalName = "Sprint",
                    LocalisationName = "SKILL_NAME_SPRINT",
                    LocalisationDescription = "SKILL_DESCRIPTION_SPRINT",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 24,
                    InternalName = "SureFeet",
                    LocalisationName = "SKILL_NAME_SUREFEET",
                    LocalisationDescription = "SKILL_DESCRIPTION_SUREFEET",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
            };
        }
        public static List<Skill> SeedPassingSkills()
        {
            return new List<Skill>
            {
                new Skill
                {
                    Id = 25,
                    InternalName = "Accurate",
                    LocalisationName = "SKILL_NAME_ACCURATE",
                    LocalisationDescription = "SKILL_DESCRIPTION_ACCURATE",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 26,
                    InternalName = "DumpOff",
                    LocalisationName = "SKILL_NAME_DUMPOFF",
                    LocalisationDescription = "SKILL_DESCRIPTION_DUMPOFF",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 27,
                    InternalName = "HailMaryPass",
                    LocalisationName = "SKILL_NAME_HAILMARYPASS",
                    LocalisationDescription = "SKILL_DESCRIPTION_HAILMARYPASS",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 28,
                    InternalName = "Leader",
                    LocalisationName = "SKILL_NAME_LEADER",
                    LocalisationDescription = "SKILL_DESCRIPTION_LEADER",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 29,
                    InternalName = "NervesOfSteel",
                    LocalisationName = "SKILL_NAME_NERVESOFSTEEL",
                    LocalisationDescription = "SKILL_DESCRIPTION_NERVESOFSTEEL",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 30,
                    InternalName = "Pass",
                    LocalisationName = "SKILL_NAME_PASS",
                    LocalisationDescription = "SKILL_DESCRIPTION_PASS",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 31,
                    InternalName = "SafeThrow",
                    LocalisationName = "SKILL_NAME_SAFETHROW",
                    LocalisationDescription = "SKILL_DESCRIPTION_SAFETHROW",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
            };
        }
        public static List<Skill> SeedStrengthSkills()
        {
            return new List<Skill>
            {
                new Skill
                {
                    Id = 32,
                    InternalName = "BreakTackle",
                    LocalisationName = "SKILL_NAME_BREAKTACLE",
                    LocalisationDescription = "SKILL_DESCRIPTION_BREAKTACLE",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 33,
                    InternalName = "Grab",
                    LocalisationName = "SKILL_NAME_GRAB",
                    LocalisationDescription = "SKILL_DESCRIPTION_GRAB",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 34,
                    InternalName = "Guard",
                    LocalisationName = "SKILL_NAME_GUARD",
                    LocalisationDescription = "SKILL_DESCRIPTION_GUARD",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 35,
                    InternalName = "Juggernaut",
                    LocalisationName = "SKILL_NAME_JUGGERNAUT",
                    LocalisationDescription = "SKILL_DESCRIPTION_JUGGERNAUT",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 36,
                    InternalName = "MightyBlow",
                    LocalisationName = "SKILL_NAME_MIGHTYBLOW",
                    LocalisationDescription = "SKILL_DESCRIPTION_MIGHTYBLOW",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 37,
                    InternalName = "MultipleBlock",
                    LocalisationName = "SKILL_NAME_MULTIPLEBLOCK",
                    LocalisationDescription = "SKILL_DESCRIPTION_MULTIPLEBLOCK",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 38,
                    InternalName = "PilingOn",
                    LocalisationName = "SKILL_NAME_PILINGON",
                    LocalisationDescription = "SKILL_DESCRIPTION_PILINGON",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 39,
                    InternalName = "StandFirm",
                    LocalisationName = "SKILL_NAME_STANDFIRM",
                    LocalisationDescription = "SKILL_DESCRIPTION_STANDFIRM",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 40,
                    InternalName = "StrongArm",
                    LocalisationName = "SKILL_NAME_STRONGARM",
                    LocalisationDescription = "SKILL_DESCRIPTION_STRONGARM",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 41,
                    InternalName = "ThickSkull",
                    LocalisationName = "SKILL_NAME_THICKSKULL",
                    LocalisationDescription = "SKILL_DESCRIPTION_THICKSKULL",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
            };
        }
        public static List<Skill> SeedMutationSkills()
        {
            return new List<Skill>
            {
                new Skill
                {
                    Id = 42,
                    InternalName = "BigHand",
                    LocalisationName = "SKILL_NAME_BIGHAND",
                    LocalisationDescription = "SKILL_DESCRIPTION_BIGHAND",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 43,
                    InternalName = "Claw",
                    LocalisationName = "SKILL_NAME_CLAWS",
                    LocalisationDescription = "SKILL_DESCRIPTION_CLAWS",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 44,
                    InternalName = "DisturbingPresence",
                    LocalisationName = "SKILL_NAME_DISTURBINGPRESENCE",
                    LocalisationDescription = "SKILL_DESCRIPTION_DISTURBINGPRESENCE",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 45,
                    InternalName = "ExtraArms",
                    LocalisationName = "SKILL_NAME_EXTRAARM",
                    LocalisationDescription = "SKILL_DESCRIPTION_EXTRAARM",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 46,
                    InternalName = "FoulAppearance",
                    LocalisationName = "SKILL_NAME_FOULAPPEARANCE",
                    LocalisationDescription = "SKILL_DESCRIPTION_FOULAPPEARANCE",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 47,
                    InternalName = "Horns",
                    LocalisationName = "SKILL_NAME_HORNS",
                    LocalisationDescription = "SKILL_DESCRIPTION_HORNS",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 48,
                    InternalName = "PrehensileTail",
                    LocalisationName = "SKILL_NAME_PREHENSIVETAIL",
                    LocalisationDescription = "SKILL_DESCRIPTION_PREHENSIVETAIL",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 49,
                    InternalName = "Tentacles",
                    LocalisationName = "SKILL_NAME_TENTACULES",
                    LocalisationDescription = "SKILL_DESCRIPTION_TENTACULES",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 50,
                    InternalName = "TwoHeads",
                    LocalisationName = "SKILL_NAME_TWOHEADS",
                    LocalisationDescription = "SKILL_DESCRIPTION_TWOHEADS",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 51,
                    InternalName = "VeryLongLegs",
                    LocalisationName = "SKILL_NAME_VERYLONGLEGS",
                    LocalisationDescription = "SKILL_DESCRIPTION_VERYLONGLEGS",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 52,
                    InternalName = "AlwaysHungry",
                    LocalisationName = "SKILL_NAME_ALWAYSHUNGRY",
                    LocalisationDescription = "SKILL_DESCRIPTION_ALWAYSHUNGRY",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
            };
        }
        public static List<Skill> SeedExtraordinarySkills()
        {
            return new List<Skill>
            {
                new Skill
                {
                    Id = 53,
                    InternalName = "Animosity",
                    LocalisationName = "SKILL_NAME_ANIMOSITY",
                    LocalisationDescription = "SKILL_DESCRIPTION_ANIMOSITY",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 54,
                    InternalName = "BallChain",
                    LocalisationName = "SKILL_NAME_BALLANDCHAIN",
                    LocalisationDescription = "SKILL_DESCRIPTION_BALLANDCHAIN",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 55,
                    InternalName = "BloodLust",
                    LocalisationName = "SKILL_NAME_BLOODLUST",
                    LocalisationDescription = "SKILL_DESCRIPTION_BLOODLUST",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 56,
                    InternalName = "Bombardier",
                    LocalisationName = "SKILL_NAME_BOMBARDIER",
                    LocalisationDescription = "SKILL_DESCRIPTION_BOMBARDIER",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 57,
                    InternalName = "BoneHead",
                    LocalisationName = "SKILL_NAME_BONEHEAD",
                    LocalisationDescription = "SKILL_DESCRIPTION_BONEHEAD",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 58,
                    InternalName = "Chainsaw",
                    LocalisationName = "SKILL_NAME_CHAINSAW",
                    LocalisationDescription = "SKILL_DESCRIPTION_CHAINSAW",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 59,
                    InternalName = "Decay",
                    LocalisationName = "SKILL_NAME_DECAY",
                    LocalisationDescription = "SKILL_DESCRIPTION_DECAY",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 60,
                    InternalName = "FanFavourite",
                    LocalisationName = "SKILL_NAME_FANFAVOURITE",
                    LocalisationDescription = "SKILL_DESCRIPTION_FANFAVOURITE",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 61,
                    InternalName = "HypnoticGaze",
                    LocalisationName = "SKILL_NAME_HYPNOTICGAZE",
                    LocalisationDescription = "SKILL_DESCRIPTION_HYPNOTICGAZE",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 62,
                    InternalName = "Loner",
                    LocalisationName = "SKILL_NAME_LONER",
                    LocalisationDescription = "SKILL_DESCRIPTION_LONER",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 63,
                    InternalName = "NoHands",
                    LocalisationName = "SKILL_NAME_NOHANDS",
                    LocalisationDescription = "SKILL_DESCRIPTION_NOHANDS",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 64,
                    InternalName = "NurglesRot",
                    LocalisationName = "SKILL_NAME_NURGLESROT",
                    LocalisationDescription = "SKILL_DESCRIPTION_NURGLESROT",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 65,
                    InternalName = "ReallyStupid",
                    LocalisationName = "SKILL_NAME_REALLYSTUPID",
                    LocalisationDescription = "SKILL_DESCRIPTION_REALLYSTUPID",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 66,
                    InternalName = "Regeneration",
                    LocalisationName = "SKILL_NAME_REGENERATION",
                    LocalisationDescription = "SKILL_DESCRIPTION_REGENERATION",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 67,
                    InternalName = "RightStuff",
                    LocalisationName = "SKILL_NAME_RIGHTSTUFF",
                    LocalisationDescription = "SKILL_DESCRIPTION_RIGHTSTUFF",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 68,
                    InternalName = "SecretWeapon",
                    LocalisationName = "SKILL_NAME_SECRETWEAPON",
                    LocalisationDescription = "SKILL_DESCRIPTION_SECRETWEAPON",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 69,
                    InternalName = "Stab",
                    LocalisationName = "SKILL_NAME_STAB",
                    LocalisationDescription = "SKILL_DESCRIPTION_STAB",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 70,
                    InternalName = "Stakes",
                    LocalisationName = "SKILL_NAME_STAKES",
                    LocalisationDescription = "SKILL_DESCRIPTION_STAKES",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 71,
                    InternalName = "Stunty",
                    LocalisationName = "SKILL_NAME_STUNTY",
                    LocalisationDescription = "SKILL_DESCRIPTION_STUNTY",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 72,
                    InternalName = "TakeRoot",
                    LocalisationName = "SKILL_NAME_TAKEROOT",
                    LocalisationDescription = "SKILL_DESCRIPTION_TAKEROOT",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 73,
                    InternalName = "ThrowTeamMate",
                    LocalisationName = "SKILL_NAME_THROWTEAMMATE",
                    LocalisationDescription = "SKILL_DESCRIPTION_THROWTEAMATE",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 74,
                    InternalName = "Titchy",
                    LocalisationName = "SKILL_NAME_TITCHY",
                    LocalisationDescription = "SKILL_DESCRIPTION_TITCHY",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 75,
                    InternalName = "WildAnimal",
                    LocalisationName = "SKILL_NAME_WILDANIMAL",
                    LocalisationDescription = "SKILL_DESCRIPTION_WILDANIMAL",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },

            };
        }
    }
}
