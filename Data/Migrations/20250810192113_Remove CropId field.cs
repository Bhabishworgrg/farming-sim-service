using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmingSimService.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCropIdfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CropId",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "CropId",
                table: "Patches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CropId",
                table: "Storage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CropId",
                table: "Patches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
