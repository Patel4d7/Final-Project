using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamManagementApp.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavoriteDish = table.Column<string>(maxLength: 50, nullable: true),
                    Skills = table.Column<string>(maxLength: 50, nullable: true),
                    Hobby1 = table.Column<string>(maxLength: 50, nullable: true),
                    Hobby2 = table.Column<string>(maxLength: 50, nullable: true),
                    MemberID = table.Column<int>(nullable: false),
                    TeamMembersID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Interests_TeamMembers_TeamMembersID",
                        column: x => x.TeamMembersID,
                        principalTable: "TeamMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DBMS = table.Column<int>(nullable: false),
                    NanoMechanics = table.Column<int>(nullable: false),
                    DataStructure = table.Column<int>(nullable: false),
                    Java = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false),
                    TeamMembersID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Marks_TeamMembers_TeamMembersID",
                        column: x => x.TeamMembersID,
                        principalTable: "TeamMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    College = table.Column<string>(nullable: false),
                    CollegeProgram = table.Column<string>(nullable: true),
                    YearInProgram = table.Column<string>(nullable: true),
                    CollegeEmail = table.Column<string>(nullable: false),
                    MemberID = table.Column<int>(nullable: false),
                    TeamMembersID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeamInfos_TeamMembers_TeamMembersID",
                        column: x => x.TeamMembersID,
                        principalTable: "TeamMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_TeamMembersID",
                table: "Interests",
                column: "TeamMembersID");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_TeamMembersID",
                table: "Marks",
                column: "TeamMembersID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInfos_TeamMembersID",
                table: "TeamInfos",
                column: "TeamMembersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "TeamInfos");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
