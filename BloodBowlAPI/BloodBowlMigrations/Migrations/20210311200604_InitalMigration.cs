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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "PlayerTypeSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTypeSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTypeSkill_PlayerType_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "PlayerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTypeSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTypeSkillCategory",
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
                    table.PrimaryKey("PK_PlayerTypeSkillCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTypeSkillCategory_LevelUpType_LevelUpTypeId",
                        column: x => x.LevelUpTypeId,
                        principalTable: "LevelUpType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTypeSkillCategory_PlayerType_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "PlayerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTypeSkillCategory_SkillCategory_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LevelUpType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Normal" },
                    { 2, "Doubles" }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "General", "G" },
                    { 2, "Strength", "S" },
                    { 3, "Passing", "P" },
                    { 4, "Agility", "A" },
                    { 6, "Extraordinary", "E" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerType_TeamTypeId",
                table: "PlayerType",
                column: "TeamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTypeSkill_PlayerTypeId",
                table: "PlayerTypeSkill",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTypeSkill_SkillId",
                table: "PlayerTypeSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTypeSkillCategory_LevelUpTypeId",
                table: "PlayerTypeSkillCategory",
                column: "LevelUpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTypeSkillCategory_PlayerTypeId",
                table: "PlayerTypeSkillCategory",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTypeSkillCategory_SkillCategoryId",
                table: "PlayerTypeSkillCategory",
                column: "SkillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillCategoryId",
                table: "Skill",
                column: "SkillCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTypeSkill");

            migrationBuilder.DropTable(
                name: "PlayerTypeSkillCategory");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "LevelUpType");

            migrationBuilder.DropTable(
                name: "PlayerType");

            migrationBuilder.DropTable(
                name: "SkillCategory");

            migrationBuilder.DropTable(
                name: "TeamType");
        }
    }
}
