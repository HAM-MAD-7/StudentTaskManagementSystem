using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTaskManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StudentTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentTasks_UserId",
                table: "StudentTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTasks_UserCredentials_UserId",
                table: "StudentTasks",
                column: "UserId",
                principalTable: "UserCredentials",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTasks_UserCredentials_UserId",
                table: "StudentTasks");

            migrationBuilder.DropIndex(
                name: "IX_StudentTasks_UserId",
                table: "StudentTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentTasks");
        }
    }
}
