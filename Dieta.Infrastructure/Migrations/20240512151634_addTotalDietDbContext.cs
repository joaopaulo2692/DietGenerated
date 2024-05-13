using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dieta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTotalDietDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TotalDiet_Diets_DietId",
                table: "TotalDiet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TotalDiet",
                table: "TotalDiet");

            migrationBuilder.RenameTable(
                name: "TotalDiet",
                newName: "TotalDiets");

            migrationBuilder.RenameIndex(
                name: "IX_TotalDiet_DietId",
                table: "TotalDiets",
                newName: "IX_TotalDiets_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TotalDiets",
                table: "TotalDiets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalDiets_Diets_DietId",
                table: "TotalDiets",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "DietId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TotalDiets_Diets_DietId",
                table: "TotalDiets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TotalDiets",
                table: "TotalDiets");

            migrationBuilder.RenameTable(
                name: "TotalDiets",
                newName: "TotalDiet");

            migrationBuilder.RenameIndex(
                name: "IX_TotalDiets_DietId",
                table: "TotalDiet",
                newName: "IX_TotalDiet_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TotalDiet",
                table: "TotalDiet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalDiet_Diets_DietId",
                table: "TotalDiet",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "DietId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
