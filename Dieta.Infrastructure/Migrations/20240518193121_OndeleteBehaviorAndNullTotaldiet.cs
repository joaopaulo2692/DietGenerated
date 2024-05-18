using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dieta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OndeleteBehaviorAndNullTotaldiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TotalDiets_DietId",
                table: "TotalDiets");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "TotalDiets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TotalDiets_DietId",
                table: "TotalDiets",
                column: "DietId",
                unique: true,
                filter: "[DietId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TotalDiets_DietId",
                table: "TotalDiets");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "TotalDiets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TotalDiets_DietId",
                table: "TotalDiets",
                column: "DietId",
                unique: true);
        }
    }
}
