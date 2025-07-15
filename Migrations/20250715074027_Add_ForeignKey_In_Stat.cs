using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmingSimService.Migrations
{
    /// <inheritdoc />
    public partial class Add_ForeignKey_In_Stat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Stats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Stats");
        }
    }
}
