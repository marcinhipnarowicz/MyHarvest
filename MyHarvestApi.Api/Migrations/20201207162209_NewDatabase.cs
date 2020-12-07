using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHarvestApi.Api.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_IdUser",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Tasks",
                newName: "IdPlot");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_IdUser",
                table: "Tasks",
                newName: "IX_Tasks_IdPlot");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BossIdUser",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdAccountType",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBoss",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    IdAccountType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.IdAccountType);
                });

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    IdPlot = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.IdPlot);
                });

            migrationBuilder.CreateTable(
                name: "StatusOfTasks",
                columns: table => new
                {
                    IdStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOfTasks", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "UsersTasks",
                columns: table => new
                {
                    IdUserTask = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUser = table.Column<int>(nullable: false),
                    IdTask = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTasks", x => x.IdUserTask);
                    table.ForeignKey(
                        name: "FK_UsersTasks_Tasks_IdTask",
                        column: x => x.IdTask,
                        principalTable: "Tasks",
                        principalColumn: "IdTask",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersTasks_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInformation",
                columns: table => new
                {
                    IdUserInformation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<string>(nullable: true),
                    IdUser = table.Column<int>(nullable: false),
                    IdTask = table.Column<int>(nullable: false),
                    IdTaskStatus = table.Column<int>(nullable: false),
                    StatusOfTaskIdStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInformation", x => x.IdUserInformation);
                    table.ForeignKey(
                        name: "FK_UsersInformation_Tasks_IdTask",
                        column: x => x.IdTask,
                        principalTable: "Tasks",
                        principalColumn: "IdTask",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInformation_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInformation_StatusOfTasks_StatusOfTaskIdStatus",
                        column: x => x.StatusOfTaskIdStatus,
                        principalTable: "StatusOfTasks",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BossIdUser",
                table: "Users",
                column: "BossIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdAccountType",
                table: "Users",
                column: "IdAccountType");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInformation_IdTask",
                table: "UsersInformation",
                column: "IdTask");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInformation_IdUser",
                table: "UsersInformation",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInformation_StatusOfTaskIdStatus",
                table: "UsersInformation",
                column: "StatusOfTaskIdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTasks_IdTask",
                table: "UsersTasks",
                column: "IdTask");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTasks_IdUser",
                table: "UsersTasks",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Plots_IdPlot",
                table: "Tasks",
                column: "IdPlot",
                principalTable: "Plots",
                principalColumn: "IdPlot",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_BossIdUser",
                table: "Users",
                column: "BossIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccountTypes_IdAccountType",
                table: "Users",
                column: "IdAccountType",
                principalTable: "AccountTypes",
                principalColumn: "IdAccountType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Plots_IdPlot",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_BossIdUser",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccountTypes_IdAccountType",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "UsersInformation");

            migrationBuilder.DropTable(
                name: "UsersTasks");

            migrationBuilder.DropTable(
                name: "StatusOfTasks");

            migrationBuilder.DropIndex(
                name: "IX_Users_BossIdUser",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdAccountType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BossIdUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdAccountType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdBoss",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "IdPlot",
                table: "Tasks",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_IdPlot",
                table: "Tasks",
                newName: "IX_Tasks_IdUser");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_IdUser",
                table: "Tasks",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
