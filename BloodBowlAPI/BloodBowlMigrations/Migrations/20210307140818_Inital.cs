using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBowlMigrations.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LevelUpType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelUpType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailableToBuy = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RerollCost = table.Column<int>(type: "int", nullable: false),
                    RerollMaximumCount = table.Column<int>(type: "int", nullable: false),
                    Apothicary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SKillTypeId = table.Column<int>(type: "int", nullable: false),
                    SkillCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_SkillCategory_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skill_SkillType_SKillTypeId",
                        column: x => x.SKillTypeId,
                        principalTable: "SkillType",
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
                    SkillCategoryId1 = table.Column<int>(type: "int", nullable: true),
                    LevelUpTypeId = table.Column<int>(type: "int", nullable: false),
                    LevelUpTypeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSkillCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableSkillCategory_LevelUpType_LevelUpTypeId1",
                        column: x => x.LevelUpTypeId1,
                        principalTable: "LevelUpType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvailableSkillCategory_PlayerType_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "PlayerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableSkillCategory_SkillCategory_SkillCategoryId1",
                        column: x => x.SkillCategoryId1,
                        principalTable: "SkillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StartiingSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartiingSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartiingSkill_PlayerType_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "PlayerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StartiingSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LevelUpType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Normal" },
                    { 2, "Doubles" }
                });

            migrationBuilder.InsertData(
                table: "SkillType",
                columns: new[] { "Id", "Cost", "Description", "IsAvailableToBuy" },
                values: new object[,]
                {
                    { 1, 10, "Skill", true },
                    { 2, null, "Extraordinary Skill", false },
                    { 3, 30, "Minor Stat-up", true },
                    { 4, 40, "Medium Stat-up", true },
                    { 5, 50, "Major Stat-up", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSkillCategory_LevelUpTypeId1",
                table: "AvailableSkillCategory",
                column: "LevelUpTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSkillCategory_PlayerTypeId",
                table: "AvailableSkillCategory",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSkillCategory_SkillCategoryId1",
                table: "AvailableSkillCategory",
                column: "SkillCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerType_TeamTypeId",
                table: "PlayerType",
                column: "TeamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillCategoryId",
                table: "Skill",
                column: "SkillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SKillTypeId",
                table: "Skill",
                column: "SKillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StartiingSkill_PlayerTypeId",
                table: "StartiingSkill",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StartiingSkill_SkillId",
                table: "StartiingSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableSkillCategory");

            migrationBuilder.DropTable(
                name: "StartiingSkill");

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
                name: "SkillType");
        }
    }
}
