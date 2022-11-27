using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamManagementApp.Migrations
{
    public partial class InitialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "TeamMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TeamMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TeamMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TeamMembers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TeamMembers");
        }
    }
}
