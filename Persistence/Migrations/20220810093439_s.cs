using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CiryName",
                table: "Address",
                newName: "CityName");

            migrationBuilder.RenameColumn(
                name: "CiryId",
                table: "Address",
                newName: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Address",
                newName: "CiryName");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Address",
                newName: "CiryId");
        }
    }
}
