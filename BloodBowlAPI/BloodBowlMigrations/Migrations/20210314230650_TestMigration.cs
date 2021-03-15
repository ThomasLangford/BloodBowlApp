using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBowlMigrations.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RerollMaximumCount",
                table: "TeamType",
                newName: "RuleSetId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TeamType",
                newName: "LocalizationName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PlayerType",
                newName: "LocalizationName");

            migrationBuilder.RenameColumn(
                name: "MaximumAllowedOnTeam",
                table: "PlayerType",
                newName: "MaximumOnTeam");

            migrationBuilder.AddColumn<string>(
                name: "InternalName",
                table: "TeamType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Necromancer",
                table: "TeamType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "InternalName",
                table: "PlayerType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TeamType",
                columns: new[] { "Id", "Apothicary", "InternalName", "LocalizationName", "Necromancer", "RerollCost", "RuleSetId" },
                values: new object[] { 1, true, "Humans", "TeamType.Name.Humans", false, 50, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TeamType_RuleSetId",
                table: "TeamType",
                column: "RuleSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamType_RuleSet_RuleSetId",
                table: "TeamType",
                column: "RuleSetId",
                principalTable: "RuleSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamType_RuleSet_RuleSetId",
                table: "TeamType");

            migrationBuilder.DropIndex(
                name: "IX_TeamType_RuleSetId",
                table: "TeamType");

            migrationBuilder.DeleteData(
                table: "TeamType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "InternalName",
                table: "TeamType");

            migrationBuilder.DropColumn(
                name: "Necromancer",
                table: "TeamType");

            migrationBuilder.DropColumn(
                name: "InternalName",
                table: "PlayerType");

            migrationBuilder.RenameColumn(
                name: "RuleSetId",
                table: "TeamType",
                newName: "RerollMaximumCount");

            migrationBuilder.RenameColumn(
                name: "LocalizationName",
                table: "TeamType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MaximumOnTeam",
                table: "PlayerType",
                newName: "MaximumAllowedOnTeam");

            migrationBuilder.RenameColumn(
                name: "LocalizationName",
                table: "PlayerType",
                newName: "Name");
        }
    }
}
