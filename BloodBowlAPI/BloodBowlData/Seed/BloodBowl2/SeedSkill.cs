using BloodBowlAPI.Models.Skills;
using BloodBowlAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlAPI.Seed.BloodBowl2
{
    public static class SeedSkill
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
                    LocalizationName = "Skill.Name.Block",
                    LocalizationDescription = "Skill.Description.BB2.Block",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 2,
                    InternalName = "Dauntless",
                    LocalizationName = "Skill.Name.Dauntless",
                    LocalizationDescription = "Skill.Description.BB2.Dauntless",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 3,
                    InternalName = "DirtyPlayer",
                    LocalizationName = "Skill.Name.DirtyPlayer",
                    LocalizationDescription = "Skill.Description.BB2.DirtyPlayer",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 4,
                    InternalName = "Fend",
                    LocalizationName = "Skill.Name.Fend",
                    LocalizationDescription = "Skill.Description.BB2.Fend",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 5,
                    InternalName = "Frenzy",
                    LocalizationName = "Skill.Name.Frenzy",
                    LocalizationDescription = "Skill.Description.BB2.Frenzy",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 6,
                    InternalName = "Kick",
                    LocalizationName = "Skill.Name.Kick",
                    LocalizationDescription = "Skill.Description.BB2.Kick",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 7,
                    InternalName = "KickOffReturn",
                    LocalizationName = "Skill.Name.KickOffReturn",
                    LocalizationDescription = "Skill.Description.BB2.KickOffReturn",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 8,
                    InternalName = "PassBlock",
                    LocalizationName = "Skill.Name.PassBlock",
                    LocalizationDescription = "Skill.Description.BB2.PassBlock",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 9,
                    InternalName = "Pro",
                    LocalizationName = "Skill.Name.Pro",
                    LocalizationDescription = "Skill.Description.BB2.Pro",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 10,
                    InternalName = "Shadowing",
                    LocalizationName = "Skill.Name.Shadowing",
                    LocalizationDescription = "Skill.Description.BB2.Shadowing",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 11,
                    InternalName = "StripBall",
                    LocalizationName = "Skill.Name.StripBall",
                    LocalizationDescription = "Skill.Description.BB2.StripBall",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 12,
                    InternalName = "SureHands",
                    LocalizationName = "Skill.Name.SureHands",
                    LocalizationDescription = "Skill.Description.BB2.SureHands",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 13,
                    InternalName = "Tackle",
                    LocalizationName = "Skill.Name.Tackle",
                    LocalizationDescription = "Skill.Description.BB2.Tackle",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 14,
                    InternalName = "Wrestle",
                    LocalizationName = "Skill.Name.Wrestle",
                    LocalizationDescription = "Skill.Description.BB2.Wrestle",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },

            };
        }
        public static List<Skill> SeedAgilitySkills()
        {
            return new List<Skill>
            {
                new Skill {
                    Id = 15,
                    InternalName = "Catch",
                    LocalizationName = "Skill.Name.Catch",
                    LocalizationDescription = "Skill.Description.BB2.Catch",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 16,
                    InternalName = "DivingCatch",
                    LocalizationName = "Skill.Name.DivingCatch",
                    LocalizationDescription = "Skill.Description.BB2.DivingCatch",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 17,
                    InternalName = "DivingTackle",
                    LocalizationName = "Skill.Name.DivingTackle",
                    LocalizationDescription = "Skill.Description.BB2.DivingTackle",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 18,
                    InternalName = "Dodge",
                    LocalizationName = "Skill.Name.Dodge",
                    LocalizationDescription = "Skill.Description.BB2.Dodge",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 19,
                    InternalName = "JumpUp",
                    LocalizationName = "Skill.Name.JumpUp",
                    LocalizationDescription = "Skill.Description.BB2.JumpUp",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 20,
                    InternalName = "Leap",  
                    LocalizationName = "Skill.Name.Leap",
                    LocalizationDescription = "Skill.Description.BB2.Leap",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 21,
                    InternalName = "SideStep",
                    LocalizationName = "Skill.Name.SideStep",
                    LocalizationDescription = "Skill.Description.BB2.SideStep",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 22,
                    InternalName = "SneakyGit",
                    LocalizationName = "Skill.Name.SneakyGit",
                    LocalizationDescription = "Skill.Description.BB2.SneakyGit",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 23,
                    InternalName = "Sprint",
                    LocalizationName = "Skill.Name.Sprint",
                    LocalizationDescription = "Skill.Description.BB2.Sprint",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 24,
                    InternalName = "SureFeet",
                    LocalizationName = "Skill.Name.SureFeet",
                    LocalizationDescription = "Skill.Description.BB2.SureFeet",
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
                    LocalizationName = "Skill.Name.Accurate",
                    LocalizationDescription = "Skill.Description.BB2.Accurate",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 26,
                    InternalName = "DumpOff",
                    LocalizationName = "Skill.Name.DumpOff",
                    LocalizationDescription = "Skill.Description.BB2.DumpOff",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 27,
                    InternalName = "HailMaryPass",
                    LocalizationName = "Skill.Name.HailMaryPass",
                    LocalizationDescription = "Skill.Description.BB2.HailMaryPass",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 28,
                    InternalName = "Leader",
                    LocalizationName = "Skill.Name.Leader",
                    LocalizationDescription = "Skill.Description.BB2.Leader",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 29,
                    InternalName = "NervesOfSteel",
                    LocalizationName = "Skill.Name.NervesOfSteel",
                    LocalizationDescription = "Skill.Description.BB2.NervesOfSteel",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 30,
                    InternalName = "Pass",
                    LocalizationName = "Skill.Name.Pass",
                    LocalizationDescription = "Skill.Description.BB2.Pass",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 31,
                    InternalName = "SafeThrow",
                    LocalizationName = "Skill.Name.SafeThrow",
                    LocalizationDescription = "Skill.Description.BB2.SafeThrow",
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
                    LocalizationName = "Skill.Name.BreakTackle",
                    LocalizationDescription = "Skill.Description.BB2.BreakTackle",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 33,
                    InternalName = "Grab",
                    LocalizationName = "Skill.Name.Grab",
                    LocalizationDescription = "Skill.Description.BB2.Grab",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 34,
                    InternalName = "Guard",
                    LocalizationName = "Skill.Name.Guard",
                    LocalizationDescription = "Skill.Description.BB2.Guard",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 35,
                    InternalName = "Juggernaut",
                    LocalizationName = "Skill.Name.Juggernaut",
                    LocalizationDescription = "Skill.Description.BB2.Juggernaut",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 36,
                    InternalName = "MightyBlow",
                    LocalizationName = "Skill.Name.MightyBlow",
                    LocalizationDescription = "Skill.Description.BB2.MightyBlow",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 37,
                    InternalName = "MultipleBlock",
                    LocalizationName = "Skill.Name.MultipleBlock",
                    LocalizationDescription = "Skill.Description.BB2.MultipleBlock",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 38,
                    InternalName = "PilingOn",
                    LocalizationName = "Skill.Name.PilingOn",
                    LocalizationDescription = "Skill.Description.BB2.PilingOn",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 39,
                    InternalName = "StandFirm",
                    LocalizationName = "Skill.Name.StandFirm",
                    LocalizationDescription = "Skill.Description.BB2.StandFirm",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 40,
                    InternalName = "StrongArm",
                    LocalizationName = "Skill.Name.StrongArm",
                    LocalizationDescription = "Skill.Description.BB2.StrongArm",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 41,
                    InternalName = "ThickSkull",
                    LocalizationName = "Skill.Name.ThickSkull",
                    LocalizationDescription = "Skill.Description.BB2.ThickSkull",
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
                    LocalizationName = "Skill.Name.BigHand",
                    LocalizationDescription = "Skill.Description.BB2.BigHand",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 43,
                    InternalName = "Claw",
                    LocalizationName = "Skill.Name.Claw",
                    LocalizationDescription = "Skill.Description.BB2.Claw",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 44,
                    InternalName = "DisturbingPresence",
                    LocalizationName = "Skill.Name.DisturbingPresence",
                    LocalizationDescription = "Skill.Description.BB2.DisturbingPresence",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 45,
                    InternalName = "ExtraArms",
                    LocalizationName = "Skill.Name.ExtraArms",
                    LocalizationDescription = "Skill.Description.BB2.ExtraArms",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 46,
                    InternalName = "FoulAppearance",
                    LocalizationName = "Skill.Name.FoulAppearance",
                    LocalizationDescription = "Skill.Description.BB2.FoulAppearance",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 47,
                    InternalName = "Horns",
                    LocalizationName = "Skill.Name.Horns",
                    LocalizationDescription = "Skill.Description.BB2.Horns",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 48,
                    InternalName = "PrehensileTail",
                    LocalizationName = "Skill.Name.PrehensileTail",
                    LocalizationDescription = "Skill.Description.BB2.PrehensileTail",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 49,
                    InternalName = "Tentacles",
                    LocalizationName = "Skill.Name.Tentacles",
                    LocalizationDescription = "Skill.Description.BB2.Tentacles",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 50,
                    InternalName = "TwoHeads",
                    LocalizationName = "Skill.Name.TwoHeads",
                    LocalizationDescription = "Skill.Description.BB2.TwoHeads",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = 51,
                    InternalName = "VeryLongLegs",
                    LocalizationName = "Skill.Name.VeryLongLegs",
                    LocalizationDescription = "Skill.Description.BB2.VeryLongLegs",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
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
                    Id = 52,
                    InternalName = "AlwaysHungry",
                    LocalizationName = "Skill.Name.AlwaysHungry",
                    LocalizationDescription = "Skill.Description.BB2.AlwaysHungry",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 53,
                    InternalName = "Animosity",
                    LocalizationName = "Skill.Name.Animosity",
                    LocalizationDescription = "Skill.Description.BB2.Animosity",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 54,
                    InternalName = "BallChain",
                    LocalizationName = "Skill.Name.BallChain",
                    LocalizationDescription = "Skill.Description.BB2.BallChain",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 55,
                    InternalName = "BloodLust",
                    LocalizationName = "Skill.Name.BloodLust",
                    LocalizationDescription = "Skill.Description.BB2.BloodLust",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 56,
                    InternalName = "Bombardier",
                    LocalizationName = "Skill.Name.Bombardier",
                    LocalizationDescription = "Skill.Description.BB2.Bombardier",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 57,
                    InternalName = "BoneHead",
                    LocalizationName = "Skill.Name.BoneHead",
                    LocalizationDescription = "Skill.Description.BB2.BoneHead",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 58,
                    InternalName = "Chainsaw",
                    LocalizationName = "Skill.Name.Chainsaw",
                    LocalizationDescription = "Skill.Description.BB2.Chainsaw",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 59,
                    InternalName = "Decay",
                    LocalizationName = "Skill.Name.Decay",
                    LocalizationDescription = "Skill.Description.BB2.Decay",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 60,
                    InternalName = "FanFavourite",
                    LocalizationName = "Skill.Name.FanFavourite",
                    LocalizationDescription = "Skill.Description.BB2.FanFavourite",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 61,
                    InternalName = "HypnoticGaze",
                    LocalizationName = "Skill.Name.HypnoticGaze",
                    LocalizationDescription = "Skill.Description.BB2.HypnoticGaze",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 62,
                    InternalName = "Loner",
                    LocalizationName = "Skill.Name.Loner",
                    LocalizationDescription = "Skill.Description.BB2.Loner",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 63,
                    InternalName = "NoHands",
                    LocalizationName = "Skill.Name.NoHands",
                    LocalizationDescription = "Skill.Description.BB2.NoHands",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 64,
                    InternalName = "NurglesRot",
                    LocalizationName = "Skill.Name.NurglesRot",
                    LocalizationDescription = "Skill.Description.BB2.NurglesRot",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = 65,
                    InternalName = "ReallyStupid",
                    LocalizationName = "Skill.Name.ReallyStupid",
                    LocalizationDescription = "Skill.Description.BB2.ReallyStupid",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 66,
                    InternalName = "Regeneration",
                    LocalizationName = "Skill.Name.Regeneration",
                    LocalizationDescription = "Skill.Description.BB2.Regeneration",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 67,
                    InternalName = "RightStuff",
                    LocalizationName = "Skill.Name.RightStuff",
                    LocalizationDescription = "Skill.Description.BB2.RightStuff",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 68,
                    InternalName = "SecretWeapon",
                    LocalizationName = "Skill.Name.SecretWeapon",
                    LocalizationDescription = "Skill.Description.BB2.SecretWeapon",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 69,
                    InternalName = "Stab",
                    LocalizationName = "Skill.Name.Stab",
                    LocalizationDescription = "Skill.Description.BB2.Stab",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 70,
                    InternalName = "Stakes",
                    LocalizationName = "Skill.Name.Stakes",
                    LocalizationDescription = "Skill.Description.BB2.Stakes",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 71,
                    InternalName = "Stunty",
                    LocalizationName = "Skill.Name.Stunty",
                    LocalizationDescription = "Skill.Description.BB2.Stunty",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 72,
                    InternalName = "TakeRoot",
                    LocalizationName = "Skill.Name.TakeRoot",
                    LocalizationDescription = "Skill.Description.BB2.TakeRoot",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 73,
                    InternalName = "ThrowTeamMate",
                    LocalizationName = "Skill.Name.ThrowTeamMate",
                    LocalizationDescription = "Skill.Description.BB2.ThrowTeamMate",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 74,
                    InternalName = "Titchy",
                    LocalizationName = "Skill.Name.Titchy",
                    LocalizationDescription = "Skill.Description.BB2.Titchy",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill 
                {
                    Id = 75,
                    InternalName = "WildAnimal",
                    LocalizationName = "Skill.Name.WildAnimal",
                    LocalizationDescription = "Skill.Description.BB2.WildAnimal",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
            };
        }
    }
}
