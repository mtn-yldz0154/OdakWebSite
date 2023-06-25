using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistCalendar.Migrations
{
    public partial class phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Payments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Payments");
        }
    }
}
