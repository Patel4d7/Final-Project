using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamManagementApp.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "TeamInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "TeamInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
