using BloodBowlData.Enums;
using BloodBowlData.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlDataTests.TestData.BloodBowl2
{
    class Skills
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
                    Id = (int)SkillBloodBowl2Enum.Block,
                    InternalName = "Block",
                    LocalizationName = "Skill.Name.Block",
                    LocalizationDescription = "Skill.Description.BB2.Block",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Dauntless,
                    InternalName = "Dauntless",
                    LocalizationName = "Skill.Name.Dauntless",
                    LocalizationDescription = "Skill.Description.BB2.Dauntless",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.DirtyPlayer,
                    InternalName = "DirtyPlayer",
                    LocalizationName = "Skill.Name.DirtyPlayer",
                    LocalizationDescription = "Skill.Description.BB2.DirtyPlayer",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Fend,
                    InternalName = "Fend",
                    LocalizationName = "Skill.Name.Fend",
                    LocalizationDescription = "Skill.Description.BB2.Fend",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Frenzy,
                    InternalName = "Frenzy",
                    LocalizationName = "Skill.Name.Frenzy",
                    LocalizationDescription = "Skill.Description.BB2.Frenzy",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Kick,
                    InternalName = "Kick",
                    LocalizationName = "Skill.Name.Kick",
                    LocalizationDescription = "Skill.Description.BB2.Kick",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.KickOffReturn,
                    InternalName = "KickOffReturn",
                    LocalizationName = "Skill.Name.KickOffReturn",
                    LocalizationDescription = "Skill.Description.BB2.KickOffReturn",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.PassBlock,
                    InternalName = "PassBlock",
                    LocalizationName = "Skill.Name.PassBlock",
                    LocalizationDescription = "Skill.Description.BB2.PassBlock",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Pro,
                    InternalName = "Pro",
                    LocalizationName = "Skill.Name.Pro",
                    LocalizationDescription = "Skill.Description.BB2.Pro",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Shadowing,
                    InternalName = "Shadowing",
                    LocalizationName = "Skill.Name.Shadowing",
                    LocalizationDescription = "Skill.Description.BB2.Shadowing",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.StripBall,
                    InternalName = "StripBall",
                    LocalizationName = "Skill.Name.StripBall",
                    LocalizationDescription = "Skill.Description.BB2.StripBall",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.SureHands,
                    InternalName = "SureHands",
                    LocalizationName = "Skill.Name.SureHands",
                    LocalizationDescription = "Skill.Description.BB2.SureHands",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Tackle,
                    InternalName = "Tackle",
                    LocalizationName = "Skill.Name.Tackle",
                    LocalizationDescription = "Skill.Description.BB2.Tackle",
                    SkillCategoryId = SkillCategoryEnum.General,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Wrestle,
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
                    Id = (int)SkillBloodBowl2Enum.Catch,
                    InternalName = "Catch",
                    LocalizationName = "Skill.Name.Catch",
                    LocalizationDescription = "Skill.Description.BB2.Catch",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.DivingCatch,
                    InternalName = "DivingCatch",
                    LocalizationName = "Skill.Name.DivingCatch",
                    LocalizationDescription = "Skill.Description.BB2.DivingCatch",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.DivingTackle,
                    InternalName = "DivingTackle",
                    LocalizationName = "Skill.Name.DivingTackle",
                    LocalizationDescription = "Skill.Description.BB2.DivingTackle",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.Dodge,
                    InternalName = "Dodge",
                    LocalizationName = "Skill.Name.Dodge",
                    LocalizationDescription = "Skill.Description.BB2.Dodge",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.JumpUp,
                    InternalName = "JumpUp",
                    LocalizationName = "Skill.Name.JumpUp",
                    LocalizationDescription = "Skill.Description.BB2.JumpUp",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.Leap,
                    InternalName = "Leap",
                    LocalizationName = "Skill.Name.Leap",
                    LocalizationDescription = "Skill.Description.BB2.Leap",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.SideStep,
                    InternalName = "SideStep",
                    LocalizationName = "Skill.Name.SideStep",
                    LocalizationDescription = "Skill.Description.BB2.SideStep",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.SneakyGit,
                    InternalName = "SneakyGit",
                    LocalizationName = "Skill.Name.SneakyGit",
                    LocalizationDescription = "Skill.Description.BB2.SneakyGit",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.Sprint,
                    InternalName = "Sprint",
                    LocalizationName = "Skill.Name.Sprint",
                    LocalizationDescription = "Skill.Description.BB2.Sprint",
                    SkillCategoryId = SkillCategoryEnum.Agility,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.SureFeet,
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
                    Id = (int)SkillBloodBowl2Enum.Accurate,
                    InternalName = "Accurate",
                    LocalizationName = "Skill.Name.Accurate",
                    LocalizationDescription = "Skill.Description.BB2.Accurate",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.DumpOff,
                    InternalName = "DumpOff",
                    LocalizationName = "Skill.Name.DumpOff",
                    LocalizationDescription = "Skill.Description.BB2.DumpOff",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.HailMaryPass,
                    InternalName = "HailMaryPass",
                    LocalizationName = "Skill.Name.HailMaryPass",
                    LocalizationDescription = "Skill.Description.BB2.HailMaryPass",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Leader,
                    InternalName = "Leader",
                    LocalizationName = "Skill.Name.Leader",
                    LocalizationDescription = "Skill.Description.BB2.Leader",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.NervesOfSteel,
                    InternalName = "NervesOfSteel",
                    LocalizationName = "Skill.Name.NervesOfSteel",
                    LocalizationDescription = "Skill.Description.BB2.NervesOfSteel",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Pass,
                    InternalName = "Pass",
                    LocalizationName = "Skill.Name.Pass",
                    LocalizationDescription = "Skill.Description.BB2.Pass",
                    SkillCategoryId = SkillCategoryEnum.Passing,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.SafeThrow,
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
                    Id = (int)SkillBloodBowl2Enum.BreakTackle,
                    InternalName = "BreakTackle",
                    LocalizationName = "Skill.Name.BreakTackle",
                    LocalizationDescription = "Skill.Description.BB2.BreakTackle",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Grab,
                    InternalName = "Grab",
                    LocalizationName = "Skill.Name.Grab",
                    LocalizationDescription = "Skill.Description.BB2.Grab",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Guard,
                    InternalName = "Guard",
                    LocalizationName = "Skill.Name.Guard",
                    LocalizationDescription = "Skill.Description.BB2.Guard",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Juggernaut,
                    InternalName = "Juggernaut",
                    LocalizationName = "Skill.Name.Juggernaut",
                    LocalizationDescription = "Skill.Description.BB2.Juggernaut",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.MightyBlow,
                    InternalName = "MightyBlow",
                    LocalizationName = "Skill.Name.MightyBlow",
                    LocalizationDescription = "Skill.Description.BB2.MightyBlow",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.MultipleBlock,
                    InternalName = "MultipleBlock",
                    LocalizationName = "Skill.Name.MultipleBlock",
                    LocalizationDescription = "Skill.Description.BB2.MultipleBlock",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.PilingOn,
                    InternalName = "PilingOn",
                    LocalizationName = "Skill.Name.PilingOn",
                    LocalizationDescription = "Skill.Description.BB2.PilingOn",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.StandFirm,
                    InternalName = "StandFirm",
                    LocalizationName = "Skill.Name.StandFirm",
                    LocalizationDescription = "Skill.Description.BB2.StandFirm",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.StrongArm,
                    InternalName = "StrongArm",
                    LocalizationName = "Skill.Name.StrongArm",
                    LocalizationDescription = "Skill.Description.BB2.StrongArm",
                    SkillCategoryId = SkillCategoryEnum.Strength,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.ThickSkull,
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
                    Id = (int)SkillBloodBowl2Enum.BigHand,
                    InternalName = "BigHand",
                    LocalizationName = "Skill.Name.BigHand",
                    LocalizationDescription = "Skill.Description.BB2.BigHand",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Claw,
                    InternalName = "Claw",
                    LocalizationName = "Skill.Name.Claw",
                    LocalizationDescription = "Skill.Description.BB2.Claw",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.DisturbingPresence,
                    InternalName = "DisturbingPresence",
                    LocalizationName = "Skill.Name.DisturbingPresence",
                    LocalizationDescription = "Skill.Description.BB2.DisturbingPresence",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.ExtraArms,
                    InternalName = "ExtraArms",
                    LocalizationName = "Skill.Name.ExtraArms",
                    LocalizationDescription = "Skill.Description.BB2.ExtraArms",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.FoulAppearance,
                    InternalName = "FoulAppearance",
                    LocalizationName = "Skill.Name.FoulAppearance",
                    LocalizationDescription = "Skill.Description.BB2.FoulAppearance",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Horns,
                    InternalName = "Horns",
                    LocalizationName = "Skill.Name.Horns",
                    LocalizationDescription = "Skill.Description.BB2.Horns",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.PrehensileTail,
                    InternalName = "PrehensileTail",
                    LocalizationName = "Skill.Name.PrehensileTail",
                    LocalizationDescription = "Skill.Description.BB2.PrehensileTail",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Tentacles,
                    InternalName = "Tentacles",
                    LocalizationName = "Skill.Name.Tentacles",
                    LocalizationDescription = "Skill.Description.BB2.Tentacles",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.TwoHeads,
                    InternalName = "TwoHeads",
                    LocalizationName = "Skill.Name.TwoHeads",
                    LocalizationDescription = "Skill.Description.BB2.TwoHeads",
                    SkillCategoryId = SkillCategoryEnum.Mutation,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill {
                    Id = (int)SkillBloodBowl2Enum.VeryLongLegs,
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
                    Id = (int)SkillBloodBowl2Enum.AlwaysHungry,
                    InternalName = "AlwaysHungry",
                    LocalizationName = "Skill.Name.AlwaysHungry",
                    LocalizationDescription = "Skill.Description.BB2.AlwaysHungry",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Animosity,
                    InternalName = "Animosity",
                    LocalizationName = "Skill.Name.Animosity",
                    LocalizationDescription = "Skill.Description.BB2.Animosity",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.BallChain,
                    InternalName = "BallChain",
                    LocalizationName = "Skill.Name.BallChain",
                    LocalizationDescription = "Skill.Description.BB2.BallChain",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.BloodLust,
                    InternalName = "BloodLust",
                    LocalizationName = "Skill.Name.BloodLust",
                    LocalizationDescription = "Skill.Description.BB2.BloodLust",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Bombardier,
                    InternalName = "Bombardier",
                    LocalizationName = "Skill.Name.Bombardier",
                    LocalizationDescription = "Skill.Description.BB2.Bombardier",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.BoneHead,
                    InternalName = "BoneHead",
                    LocalizationName = "Skill.Name.BoneHead",
                    LocalizationDescription = "Skill.Description.BB2.BoneHead",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Chainsaw,
                    InternalName = "Chainsaw",
                    LocalizationName = "Skill.Name.Chainsaw",
                    LocalizationDescription = "Skill.Description.BB2.Chainsaw",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Decay,
                    InternalName = "Decay",
                    LocalizationName = "Skill.Name.Decay",
                    LocalizationDescription = "Skill.Description.BB2.Decay",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.FanFavourite,
                    InternalName = "FanFavourite",
                    LocalizationName = "Skill.Name.FanFavourite",
                    LocalizationDescription = "Skill.Description.BB2.FanFavourite",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.HypnoticGaze,
                    InternalName = "HypnoticGaze",
                    LocalizationName = "Skill.Name.HypnoticGaze",
                    LocalizationDescription = "Skill.Description.BB2.HypnoticGaze",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Loner,
                    InternalName = "Loner",
                    LocalizationName = "Skill.Name.Loner",
                    LocalizationDescription = "Skill.Description.BB2.Loner",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.NoHands,
                    InternalName = "NoHands",
                    LocalizationName = "Skill.Name.NoHands",
                    LocalizationDescription = "Skill.Description.BB2.NoHands",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.NurglesRot,
                    InternalName = "NurglesRot",
                    LocalizationName = "Skill.Name.NurglesRot",
                    LocalizationDescription = "Skill.Description.BB2.NurglesRot",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.ReallyStupid,
                    InternalName = "ReallyStupid",
                    LocalizationName = "Skill.Name.ReallyStupid",
                    LocalizationDescription = "Skill.Description.BB2.ReallyStupid",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Regeneration,
                    InternalName = "Regeneration",
                    LocalizationName = "Skill.Name.Regeneration",
                    LocalizationDescription = "Skill.Description.BB2.Regeneration",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.RightStuff,
                    InternalName = "RightStuff",
                    LocalizationName = "Skill.Name.RightStuff",
                    LocalizationDescription = "Skill.Description.BB2.RightStuff",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.SecretWeapon,
                    InternalName = "SecretWeapon",
                    LocalizationName = "Skill.Name.SecretWeapon",
                    LocalizationDescription = "Skill.Description.BB2.SecretWeapon",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Stab,
                    InternalName = "Stab",
                    LocalizationName = "Skill.Name.Stab",
                    LocalizationDescription = "Skill.Description.BB2.Stab",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Stakes,
                    InternalName = "Stakes",
                    LocalizationName = "Skill.Name.Stakes",
                    LocalizationDescription = "Skill.Description.BB2.Stakes",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Stunty,
                    InternalName = "Stunty",
                    LocalizationName = "Skill.Name.Stunty",
                    LocalizationDescription = "Skill.Description.BB2.Stunty",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.TakeRoot,
                    InternalName = "TakeRoot",
                    LocalizationName = "Skill.Name.TakeRoot",
                    LocalizationDescription = "Skill.Description.BB2.TakeRoot",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.ThrowTeamMate,
                    InternalName = "ThrowTeamMate",
                    LocalizationName = "Skill.Name.ThrowTeamMate",
                    LocalizationDescription = "Skill.Description.BB2.ThrowTeamMate",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.Titchy,
                    InternalName = "Titchy",
                    LocalizationName = "Skill.Name.Titchy",
                    LocalizationDescription = "Skill.Description.BB2.Titchy",
                    SkillCategoryId = SkillCategoryEnum.Extraordinary,
                    RuleSetId = RuleSetEnum.BloodBowl2
                },
                new Skill
                {
                    Id = (int)SkillBloodBowl2Enum.WildAnimal,
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
