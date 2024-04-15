using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    GastoMetaBasal = table.Column<double>(type: "float", nullable: false),
                    TreinoFreq = table.Column<int>(type: "int", nullable: false),
                    DietaId = table.Column<int>(type: "int", nullable: false),
                    tipoDieta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    informacaoAdd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Dietas",
                columns: table => new
                {
                    DietaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietas", x => x.DietaId);
                    table.ForeignKey(
                        name: "FK_Dietas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    AlimentosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carboidrato = table.Column<double>(type: "float", nullable: false),
                    Lipidio = table.Column<double>(type: "float", nullable: false),
                    Proteina = table.Column<double>(type: "float", nullable: false),
                    Kcal = table.Column<double>(type: "float", nullable: false),
                    Preparo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fibra = table.Column<double>(type: "float", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    DietaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.AlimentosId);
                    table.ForeignKey(
                        name: "FK_Alimentos_Dietas_DietaId",
                        column: x => x.DietaId,
                        principalTable: "Dietas",
                        principalColumn: "DietaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_DietaId",
                table: "Alimentos",
                column: "DietaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dietas_ClienteId",
                table: "Dietas",
                column: "ClienteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "Dietas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
