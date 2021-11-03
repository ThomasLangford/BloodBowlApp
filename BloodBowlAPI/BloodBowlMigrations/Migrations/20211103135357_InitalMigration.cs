using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBowlMigrations.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LevelUpType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LocalizationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelUpType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ruleset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LocalizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supported = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruleset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InternalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalizationShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalizationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RerollCost = table.Column<int>(type: "int", nullable: false),
                    Apothicary = table.Column<bool>(type: "bit", nullable: false),
                    Necromancer = table.Column<bool>(type: "bit", nullable: false),
                    RuleSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamType_Ruleset_RuleSetId",
                        column: x => x.RuleSetId,
                        principalTable: "Ruleset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LocalizationName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LocalizationDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SkillCategoryId = table.Column<int>(type: "int", nullable: false),
                    RuleSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Ruleset_RuleSetId",
                        column: x => x.RuleSetId,
                        principalTable: "Ruleset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skill_SkillCategory_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumAllowedOnTeam = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Move = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    ArmourValue = table.Column<int>(type: "int", nullable: false),
                    TeamTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerType_TeamType_TeamTypeId",
                        column: x => x.TeamTypeId,
                        principalTable: "TeamType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableSkillCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false),
                    SkillCategoryId = table.Column<int>(type: "int", nullable: false),
                    LevelUpTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSkillCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableSkillCategory_LevelUpType_LevelUpTypeId",
                        column: x => x.LevelUpTypeId,
                        principalTable: "LevelUpType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableSkillCategory_PlayerType_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "PlayerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableSkillCategory_SkillCategory_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StartingSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartingSkill_PlayerType_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "PlayerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StartingSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LevelUpType",
                columns: new[] { "Id", "LocalizationName" },
                values: new object[,]
                {
                    { 1, "LevelUpType.Name.Normal" },
                    { 2, "LevelUpType.Name.Double" }
                });

            migrationBuilder.InsertData(
                table: "Ruleset",
                columns: new[] { "Id", "LocalizationName", "Supported" },
                values: new object[,]
                {
                    { 1, "Ruleset.Name.BloodBowl2", true },
                    { 2, "Ruleset.Name.BloodBowl3", true },
                    { 3, "Ruleset.Name.BloodBowlSeason2", false }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "InternalName", "LocalizationName", "LocalizationShortName" },
                values: new object[,]
                {
                    { 1, "General", "SkillCategory.Name.General", "SkillCategory.ShortName.General" },
                    { 2, "Strength", "SkillCategory.Name.Strength", "SkillCategory.ShortName.Strength" },
                    { 3, "Passing", "SkillCategory.Name.Passing", "SkillCategory.ShortName.Passing" },
                    { 4, "Agility", "SkillCategory.Name.Agility", "SkillCategory.ShortName.Agility" },
                    { 5, "Mutation", "SkillCategory.Name.Mutation", "SkillCategory.ShortName.Mutation" },
                    { 6, "Extraordinary", "SkillCategory.Name.Extraordinary", "SkillCategory.ShortName.Extraordinary" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "InternalName", "LocalizationDescription", "LocalizationName", "RuleSetId", "SkillCategoryId" },
                values: new object[,]
                {
                    { 1, "Block", "Skill.Description.BB2.Block", "Skill.Name.Block", 1, 1 },
                    { 54, "BallChain", "Skill.Description.BB2.BallChain", "Skill.Name.BallChain", 1, 6 },
                    { 53, "Animosity", "Skill.Description.BB2.Animosity", "Skill.Name.Animosity", 1, 6 },
                    { 52, "AlwaysHungry", "Skill.Description.BB2.AlwaysHungry", "Skill.Name.AlwaysHungry", 1, 6 },
                    { 51, "VeryLongLegs", "Skill.Description.BB2.VeryLongLegs", "Skill.Name.VeryLongLegs", 1, 5 },
                    { 50, "TwoHeads", "Skill.Description.BB2.TwoHeads", "Skill.Name.TwoHeads", 1, 5 },
                    { 49, "Tentacles", "Skill.Description.BB2.Tentacles", "Skill.Name.Tentacles", 1, 5 },
                    { 48, "PrehensileTail", "Skill.Description.BB2.PrehensileTail", "Skill.Name.PrehensileTail", 1, 5 },
                    { 47, "Horns", "Skill.Description.BB2.Horns", "Skill.Name.Horns", 1, 5 },
                    { 46, "FoulAppearance", "Skill.Description.BB2.FoulAppearance", "Skill.Name.FoulAppearance", 1, 5 },
                    { 45, "ExtraArms", "Skill.Description.BB2.ExtraArms", "Skill.Name.ExtraArms", 1, 5 },
                    { 44, "DisturbingPresence", "Skill.Description.BB2.DisturbingPresence", "Skill.Name.DisturbingPresence", 1, 5 },
                    { 43, "Claw", "Skill.Description.BB2.Claw", "Skill.Name.Claw", 1, 5 },
                    { 42, "BigHand", "Skill.Description.BB2.BigHand", "Skill.Name.BigHand", 1, 5 },
                    { 24, "SureFeet", "Skill.Description.BB2.SureFeet", "Skill.Name.SureFeet", 1, 4 },
                    { 23, "Sprint", "Skill.Description.BB2.Sprint", "Skill.Name.Sprint", 1, 4 },
                    { 55, "BloodLust", "Skill.Description.BB2.BloodLust", "Skill.Name.BloodLust", 1, 6 },
                    { 22, "SneakyGit", "Skill.Description.BB2.SneakyGit", "Skill.Name.SneakyGit", 1, 4 },
                    { 56, "Bombardier", "Skill.Description.BB2.Bombardier", "Skill.Name.Bombardier", 1, 6 },
                    { 58, "Chainsaw", "Skill.Description.BB2.Chainsaw", "Skill.Name.Chainsaw", 1, 6 },
                    { 73, "ThrowTeamMate", "Skill.Description.BB2.ThrowTeamMate", "Skill.Name.ThrowTeamMate", 1, 6 },
                    { 72, "TakeRoot", "Skill.Description.BB2.TakeRoot", "Skill.Name.TakeRoot", 1, 6 },
                    { 71, "Stunty", "Skill.Description.BB2.Stunty", "Skill.Name.Stunty", 1, 6 },
                    { 70, "Stakes", "Skill.Description.BB2.Stakes", "Skill.Name.Stakes", 1, 6 },
                    { 69, "Stab", "Skill.Description.BB2.Stab", "Skill.Name.Stab", 1, 6 },
                    { 68, "SecretWeapon", "Skill.Description.BB2.SecretWeapon", "Skill.Name.SecretWeapon", 1, 6 },
                    { 67, "RightStuff", "Skill.Description.BB2.RightStuff", "Skill.Name.RightStuff", 1, 6 },
                    { 66, "Regeneration", "Skill.Description.BB2.Regeneration", "Skill.Name.Regeneration", 1, 6 },
                    { 65, "ReallyStupid", "Skill.Description.BB2.ReallyStupid", "Skill.Name.ReallyStupid", 1, 6 },
                    { 64, "NurglesRot", "Skill.Description.BB2.NurglesRot", "Skill.Name.NurglesRot", 1, 6 },
                    { 63, "NoHands", "Skill.Description.BB2.NoHands", "Skill.Name.NoHands", 1, 6 },
                    { 62, "Loner", "Skill.Description.BB2.Loner", "Skill.Name.Loner", 1, 6 },
                    { 61, "HypnoticGaze", "Skill.Description.BB2.HypnoticGaze", "Skill.Name.HypnoticGaze", 1, 6 },
                    { 60, "FanFavourite", "Skill.Description.BB2.FanFavourite", "Skill.Name.FanFavourite", 1, 6 },
                    { 59, "Decay", "Skill.Description.BB2.Decay", "Skill.Name.Decay", 1, 6 },
                    { 57, "BoneHead", "Skill.Description.BB2.BoneHead", "Skill.Name.BoneHead", 1, 6 },
                    { 74, "Titchy", "Skill.Description.BB2.Titchy", "Skill.Name.Titchy", 1, 6 },
                    { 21, "SideStep", "Skill.Description.BB2.SideStep", "Skill.Name.SideStep", 1, 4 },
                    { 19, "JumpUp", "Skill.Description.BB2.JumpUp", "Skill.Name.JumpUp", 1, 4 },
                    { 33, "Grab", "Skill.Description.BB2.Grab", "Skill.Name.Grab", 1, 2 },
                    { 32, "BreakTackle", "Skill.Description.BB2.BreakTackle", "Skill.Name.BreakTackle", 1, 2 },
                    { 14, "Wrestle", "Skill.Description.BB2.Wrestle", "Skill.Name.Wrestle", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "InternalName", "LocalizationDescription", "LocalizationName", "RuleSetId", "SkillCategoryId" },
                values: new object[,]
                {
                    { 13, "Tackle", "Skill.Description.BB2.Tackle", "Skill.Name.Tackle", 1, 1 },
                    { 12, "SureHands", "Skill.Description.BB2.SureHands", "Skill.Name.SureHands", 1, 1 },
                    { 11, "StripBall", "Skill.Description.BB2.StripBall", "Skill.Name.StripBall", 1, 1 },
                    { 10, "Shadowing", "Skill.Description.BB2.Shadowing", "Skill.Name.Shadowing", 1, 1 },
                    { 9, "Pro", "Skill.Description.BB2.Pro", "Skill.Name.Pro", 1, 1 },
                    { 8, "PassBlock", "Skill.Description.BB2.PassBlock", "Skill.Name.PassBlock", 1, 1 },
                    { 7, "KickOffReturn", "Skill.Description.BB2.KickOffReturn", "Skill.Name.KickOffReturn", 1, 1 },
                    { 6, "Kick", "Skill.Description.BB2.Kick", "Skill.Name.Kick", 1, 1 },
                    { 5, "Frenzy", "Skill.Description.BB2.Frenzy", "Skill.Name.Frenzy", 1, 1 },
                    { 4, "Fend", "Skill.Description.BB2.Fend", "Skill.Name.Fend", 1, 1 },
                    { 3, "DirtyPlayer", "Skill.Description.BB2.DirtyPlayer", "Skill.Name.DirtyPlayer", 1, 1 },
                    { 2, "Dauntless", "Skill.Description.BB2.Dauntless", "Skill.Name.Dauntless", 1, 1 },
                    { 34, "Guard", "Skill.Description.BB2.Guard", "Skill.Name.Guard", 1, 2 },
                    { 20, "Leap", "Skill.Description.BB2.Leap", "Skill.Name.Leap", 1, 4 },
                    { 35, "Juggernaut", "Skill.Description.BB2.Juggernaut", "Skill.Name.Juggernaut", 1, 2 },
                    { 37, "MultipleBlock", "Skill.Description.BB2.MultipleBlock", "Skill.Name.MultipleBlock", 1, 2 },
                    { 18, "Dodge", "Skill.Description.BB2.Dodge", "Skill.Name.Dodge", 1, 4 },
                    { 17, "DivingTackle", "Skill.Description.BB2.DivingTackle", "Skill.Name.DivingTackle", 1, 4 },
                    { 16, "DivingCatch", "Skill.Description.BB2.DivingCatch", "Skill.Name.DivingCatch", 1, 4 },
                    { 15, "Catch", "Skill.Description.BB2.Catch", "Skill.Name.Catch", 1, 4 },
                    { 31, "SafeThrow", "Skill.Description.BB2.SafeThrow", "Skill.Name.SafeThrow", 1, 3 },
                    { 30, "Pass", "Skill.Description.BB2.Pass", "Skill.Name.Pass", 1, 3 },
                    { 29, "NervesOfSteel", "Skill.Description.BB2.NervesOfSteel", "Skill.Name.NervesOfSteel", 1, 3 },
                    { 28, "Leader", "Skill.Description.BB2.Leader", "Skill.Name.Leader", 1, 3 },
                    { 27, "HailMaryPass", "Skill.Description.BB2.HailMaryPass", "Skill.Name.HailMaryPass", 1, 3 },
                    { 26, "DumpOff", "Skill.Description.BB2.DumpOff", "Skill.Name.DumpOff", 1, 3 },
                    { 25, "Accurate", "Skill.Description.BB2.Accurate", "Skill.Name.Accurate", 1, 3 },
                    { 41, "ThickSkull", "Skill.Description.BB2.ThickSkull", "Skill.Name.ThickSkull", 1, 2 },
                    { 40, "StrongArm", "Skill.Description.BB2.StrongArm", "Skill.Name.StrongArm", 1, 2 },
                    { 39, "StandFirm", "Skill.Description.BB2.StandFirm", "Skill.Name.StandFirm", 1, 2 },
                    { 38, "PilingOn", "Skill.Description.BB2.PilingOn", "Skill.Name.PilingOn", 1, 2 },
                    { 36, "MightyBlow", "Skill.Description.BB2.MightyBlow", "Skill.Name.MightyBlow", 1, 2 },
                    { 75, "WildAnimal", "Skill.Description.BB2.WildAnimal", "Skill.Name.WildAnimal", 1, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSkillCategory_LevelUpTypeId",
                table: "AvailableSkillCategory",
                column: "LevelUpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSkillCategory_PlayerTypeId",
                table: "AvailableSkillCategory",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSkillCategory_SkillCategoryId",
                table: "AvailableSkillCategory",
                column: "SkillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerType_TeamTypeId",
                table: "PlayerType",
                column: "TeamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_RuleSetId",
                table: "Skill",
                column: "RuleSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillCategoryId",
                table: "Skill",
                column: "SkillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StartingSkill_PlayerTypeId",
                table: "StartingSkill",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StartingSkill_SkillId",
                table: "StartingSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamType_RuleSetId",
                table: "TeamType",
                column: "RuleSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableSkillCategory");

            migrationBuilder.DropTable(
                name: "StartingSkill");

            migrationBuilder.DropTable(
                name: "LevelUpType");

            migrationBuilder.DropTable(
                name: "PlayerType");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "TeamType");

            migrationBuilder.DropTable(
                name: "SkillCategory");

            migrationBuilder.DropTable(
                name: "Ruleset");
        }
    }
}
