using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeTasks.Data.Migrations
{
    public partial class revertbackclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_PersonDoing",
                table: "TaskItems");

            migrationBuilder.RenameColumn(
                name: "PersonDoing",
                table: "TaskItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_PersonDoing",
                table: "TaskItems",
                newName: "IX_TaskItems_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TaskItems",
                newName: "PersonDoing");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems",
                newName: "IX_TaskItems_PersonDoing");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_PersonDoing",
                table: "TaskItems",
                column: "PersonDoing",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
