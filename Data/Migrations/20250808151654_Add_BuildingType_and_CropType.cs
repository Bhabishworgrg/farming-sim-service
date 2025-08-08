using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FarmingSimService.Migrations
{
    /// <inheritdoc />
    public partial class Add_BuildingType_and_CropType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CropId",
                table: "Storage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CropTypeId",
                table: "Storage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Players",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CropId",
                table: "Patches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CropTypeId",
                table: "Patches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuildingTypeId",
                table: "Buildings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BaseCost = table.Column<int>(type: "integer", nullable: false),
                    BuildTimeSeconds = table.Column<int>(type: "integer", nullable: false),
                    MaxLevel = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GrowthTimeSeconds = table.Column<int>(type: "integer", nullable: false),
                    SeedCost = table.Column<int>(type: "integer", nullable: false),
                    SellPrice = table.Column<int>(type: "integer", nullable: false),
                    HarvestQuality = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storage_CropTypeId",
                table: "Storage",
                column: "CropTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patches_CropTypeId",
                table: "Patches",
                column: "CropTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingTypeId",
                table: "Buildings",
                column: "BuildingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_BuildingType_BuildingTypeId",
                table: "Buildings",
                column: "BuildingTypeId",
                principalTable: "BuildingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patches_CropType_CropTypeId",
                table: "Patches",
                column: "CropTypeId",
                principalTable: "CropType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_CropType_CropTypeId",
                table: "Storage",
                column: "CropTypeId",
                principalTable: "CropType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_BuildingType_BuildingTypeId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Patches_CropType_CropTypeId",
                table: "Patches");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_CropType_CropTypeId",
                table: "Storage");

            migrationBuilder.DropTable(
                name: "BuildingType");

            migrationBuilder.DropTable(
                name: "CropType");

            migrationBuilder.DropIndex(
                name: "IX_Storage_CropTypeId",
                table: "Storage");

            migrationBuilder.DropIndex(
                name: "IX_Players_UserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Patches_CropTypeId",
                table: "Patches");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_BuildingTypeId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CropId",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "CropTypeId",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CropId",
                table: "Patches");

            migrationBuilder.DropColumn(
                name: "CropTypeId",
                table: "Patches");

            migrationBuilder.DropColumn(
                name: "BuildingTypeId",
                table: "Buildings");
        }
    }
}
