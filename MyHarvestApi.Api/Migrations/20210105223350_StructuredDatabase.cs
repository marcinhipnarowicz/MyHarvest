using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHarvestApi.Api.Migrations
{
    public partial class StructuredDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersTasks");

            migrationBuilder.AddColumn<double>(
                name: "XCoordinate",
                table: "Plots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YCoordinate",
                table: "Plots",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XCoordinate",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "YCoordinate",
                table: "Plots");

            migrationBuilder.CreateTable(
                name: "UsersTasks",
                columns: table => new
                {
                    IdUserTask = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTask = table.Column<int>(nullable: true),
                    IdUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTasks", x => x.IdUserTask);
                    table.ForeignKey(
                        name: "FK_UsersTasks_Tasks_IdTask",
                        column: x => x.IdTask,
                        principalTable: "Tasks",
                        principalColumn: "IdTask",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersTasks_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersTasks_IdTask",
                table: "UsersTasks",
                column: "IdTask");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTasks_IdUser",
                table: "UsersTasks",
                column: "IdUser");
        }
    }
}
