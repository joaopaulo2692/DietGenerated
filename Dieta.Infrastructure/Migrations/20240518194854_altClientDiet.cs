using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dieta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class altClientDiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteDiet");

            migrationBuilder.CreateTable(
                name: "ClientDiet",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DietsDietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDiet", x => new { x.ClientId, x.DietsDietId });
                    table.ForeignKey(
                        name: "FK_ClientDiet_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientDiet_Diets_DietsDietId",
                        column: x => x.DietsDietId,
                        principalTable: "Diets",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDiet_DietsDietId",
                table: "ClientDiet",
                column: "DietsDietId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDiet");

            migrationBuilder.CreateTable(
                name: "ClienteDiet",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteDiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteDiet_Clientes_ClienteId",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteDiet_Dietas_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "DietId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDiet_DietId",
                table: "ClienteDiet",
                column: "DietId");
        }
    }
}
