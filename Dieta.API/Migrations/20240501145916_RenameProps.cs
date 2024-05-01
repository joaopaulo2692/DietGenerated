using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dieta.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlimentosRefeicao_Alimentos_AlimentosId",
                table: "AlimentosRefeicao");

            migrationBuilder.DropForeignKey(
                name: "FK_AlimentosRefeicao_Refeicoes_RefeicaoId",
                table: "AlimentosRefeicao");

            migrationBuilder.DropTable(
                name: "DietRefeicao");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Refeicoes");

            migrationBuilder.RenameColumn(
                name: "NomeRefeicao",
                table: "Refeicoes",
                newName: "NameMeal");

            migrationBuilder.RenameColumn(
                name: "RefeicaoId",
                table: "Refeicoes",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "TipoDieta",
                table: "Dietas",
                newName: "DietType");

            migrationBuilder.RenameColumn(
                name: "NomeDieta",
                table: "Dietas",
                newName: "DietName");

            migrationBuilder.RenameColumn(
                name: "tipoDieta",
                table: "Clientes",
                newName: "informationAdd");

            migrationBuilder.RenameColumn(
                name: "informacaoAdd",
                table: "Clientes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TreinoFreq",
                table: "Clientes",
                newName: "TrainingFreq");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Clientes",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Clientes",
                newName: "DietType");

            migrationBuilder.RenameColumn(
                name: "Idade",
                table: "Clientes",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "GastoMetaBasal",
                table: "Clientes",
                newName: "BasalMeatabolicRate");

            migrationBuilder.RenameColumn(
                name: "Altura",
                table: "Clientes",
                newName: "Heigth");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Clientes",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "RefeicaoId",
                table: "AlimentosRefeicao",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "AlimentosId",
                table: "AlimentosRefeicao",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_AlimentosRefeicao_RefeicaoId",
                table: "AlimentosRefeicao",
                newName: "IX_AlimentosRefeicao_MealId");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Alimentos",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "Proteina",
                table: "Alimentos",
                newName: "Fiber");

            migrationBuilder.RenameColumn(
                name: "Preparo",
                table: "Alimentos",
                newName: "Prepare");

            migrationBuilder.RenameColumn(
                name: "Lipidio",
                table: "Alimentos",
                newName: "Fat");

            migrationBuilder.RenameColumn(
                name: "Fibra",
                table: "Alimentos",
                newName: "Carb");

            migrationBuilder.RenameColumn(
                name: "Carboidrato",
                table: "Alimentos",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Alimento",
                table: "Alimentos",
                newName: "FoodName");

            migrationBuilder.RenameColumn(
                name: "AlimentosId",
                table: "Alimentos",
                newName: "FoodId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Refeicoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DietMeal",
                columns: table => new
                {
                    DietsDietId = table.Column<int>(type: "int", nullable: false),
                    MealsMealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietMeal", x => new { x.DietsDietId, x.MealsMealId });
                    table.ForeignKey(
                        name: "FK_DietMeal_Dietas_DietsDietId",
                        column: x => x.DietsDietId,
                        principalTable: "Dietas",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietMeal_Refeicoes_MealsMealId",
                        column: x => x.MealsMealId,
                        principalTable: "Refeicoes",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietMeal_MealsMealId",
                table: "DietMeal",
                column: "MealsMealId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlimentosRefeicao_Alimentos_FoodId",
                table: "AlimentosRefeicao",
                column: "FoodId",
                principalTable: "Alimentos",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlimentosRefeicao_Refeicoes_MealId",
                table: "AlimentosRefeicao",
                column: "MealId",
                principalTable: "Refeicoes",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlimentosRefeicao_Alimentos_FoodId",
                table: "AlimentosRefeicao");

            migrationBuilder.DropForeignKey(
                name: "FK_AlimentosRefeicao_Refeicoes_MealId",
                table: "AlimentosRefeicao");

            migrationBuilder.DropTable(
                name: "DietMeal");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Refeicoes");

            migrationBuilder.RenameColumn(
                name: "NameMeal",
                table: "Refeicoes",
                newName: "NomeRefeicao");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Refeicoes",
                newName: "RefeicaoId");

            migrationBuilder.RenameColumn(
                name: "DietType",
                table: "Dietas",
                newName: "TipoDieta");

            migrationBuilder.RenameColumn(
                name: "DietName",
                table: "Dietas",
                newName: "NomeDieta");

            migrationBuilder.RenameColumn(
                name: "informationAdd",
                table: "Clientes",
                newName: "tipoDieta");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Clientes",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "TrainingFreq",
                table: "Clientes",
                newName: "TreinoFreq");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clientes",
                newName: "informacaoAdd");

            migrationBuilder.RenameColumn(
                name: "Heigth",
                table: "Clientes",
                newName: "Altura");

            migrationBuilder.RenameColumn(
                name: "DietType",
                table: "Clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "BasalMeatabolicRate",
                table: "Clientes",
                newName: "GastoMetaBasal");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Clientes",
                newName: "Idade");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clientes",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "AlimentosRefeicao",
                newName: "RefeicaoId");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "AlimentosRefeicao",
                newName: "AlimentosId");

            migrationBuilder.RenameIndex(
                name: "IX_AlimentosRefeicao_MealId",
                table: "AlimentosRefeicao",
                newName: "IX_AlimentosRefeicao_RefeicaoId");

            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "Alimentos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "Prepare",
                table: "Alimentos",
                newName: "Preparo");

            migrationBuilder.RenameColumn(
                name: "FoodName",
                table: "Alimentos",
                newName: "Alimento");

            migrationBuilder.RenameColumn(
                name: "Fiber",
                table: "Alimentos",
                newName: "Proteina");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "Alimentos",
                newName: "Lipidio");

            migrationBuilder.RenameColumn(
                name: "Carb",
                table: "Alimentos",
                newName: "Fibra");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Alimentos",
                newName: "Carboidrato");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "Alimentos",
                newName: "AlimentosId");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Horario",
                table: "Refeicoes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "DietRefeicao",
                columns: table => new
                {
                    DietaDietId = table.Column<int>(type: "int", nullable: false),
                    RefeicoesRefeicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietRefeicao", x => new { x.DietaDietId, x.RefeicoesRefeicaoId });
                    table.ForeignKey(
                        name: "FK_DietRefeicao_Dietas_DietaDietId",
                        column: x => x.DietaDietId,
                        principalTable: "Dietas",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietRefeicao_Refeicoes_RefeicoesRefeicaoId",
                        column: x => x.RefeicoesRefeicaoId,
                        principalTable: "Refeicoes",
                        principalColumn: "RefeicaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietRefeicao_RefeicoesRefeicaoId",
                table: "DietRefeicao",
                column: "RefeicoesRefeicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlimentosRefeicao_Alimentos_AlimentosId",
                table: "AlimentosRefeicao",
                column: "AlimentosId",
                principalTable: "Alimentos",
                principalColumn: "AlimentosId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlimentosRefeicao_Refeicoes_RefeicaoId",
                table: "AlimentosRefeicao",
                column: "RefeicaoId",
                principalTable: "Refeicoes",
                principalColumn: "RefeicaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
