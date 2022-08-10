using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Address",
                newName: "StreetName");

            migrationBuilder.AddColumn<string>(
                name: "CiryName",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CiryName",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Address",
                newName: "Street");
        }
    }
}
