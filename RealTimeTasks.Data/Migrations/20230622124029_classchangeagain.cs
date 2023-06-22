using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeTasks.Data.Migrations
{
    public partial class classchangeagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskItems");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_PersonDoing",
                table: "TaskItems",
                column: "PersonDoing");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_PersonDoing",
                table: "TaskItems",
                column: "PersonDoing",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_PersonDoing",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_PersonDoing",
                table: "TaskItems");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TaskItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
