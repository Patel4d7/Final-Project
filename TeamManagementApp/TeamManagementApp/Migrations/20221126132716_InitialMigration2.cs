using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamManagementApp.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Interests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Interests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
