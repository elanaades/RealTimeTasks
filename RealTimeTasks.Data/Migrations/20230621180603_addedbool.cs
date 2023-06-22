using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeTasks.Data.Migrations
{
    public partial class addedbool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "TaskItems",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "TaskItems");
        }
    }
}
