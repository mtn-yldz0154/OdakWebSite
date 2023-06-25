using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistCalendar.Migrations
{
    public partial class pass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pass",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pass",
                table: "AspNetUsers");
        }
    }
}
