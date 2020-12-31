using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHarvestApi.Api.Migrations
{
    public partial class AddTableWaypointAndPOintOnTheMap2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointsOnTheMap",
                columns: table => new
                {
                    IdPointOnTheMap = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    XCoordinate = table.Column<double>(nullable: false),
                    YCoordinate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsOnTheMap", x => x.IdPointOnTheMap);
                });

            migrationBuilder.CreateTable(
                name: "Waypoints",
                columns: table => new
                {
                    IdWaypoint = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUserInformation = table.Column<int>(nullable: true),
                    IdPointOnTheMap = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waypoints", x => x.IdWaypoint);
                    table.ForeignKey(
                        name: "FK_Waypoints_PointsOnTheMap_IdPointOnTheMap",
                        column: x => x.IdPointOnTheMap,
                        principalTable: "PointsOnTheMap",
                        principalColumn: "IdPointOnTheMap",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Waypoints_UsersInformation_IdUserInformation",
                        column: x => x.IdUserInformation,
                        principalTable: "UsersInformation",
                        principalColumn: "IdUserInformation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waypoints_IdPointOnTheMap",
                table: "Waypoints",
                column: "IdPointOnTheMap");

            migrationBuilder.CreateIndex(
                name: "IX_Waypoints_IdUserInformation",
                table: "Waypoints",
                column: "IdUserInformation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Waypoints");

            migrationBuilder.DropTable(
                name: "PointsOnTheMap");
        }
    }
}
