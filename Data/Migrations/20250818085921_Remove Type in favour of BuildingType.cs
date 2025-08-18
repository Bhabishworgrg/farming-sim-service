using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmingSimService.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTypeinfavourofBuildingType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Buildings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Buildings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
