using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class fixOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkId",
                table: "Offices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkId",
                table: "Offices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
