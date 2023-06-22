using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeTasks.Data.Migrations
{
    public partial class classchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonDoing",
                table: "TaskItems",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonDoing",
                table: "TaskItems");
        }
    }
}
