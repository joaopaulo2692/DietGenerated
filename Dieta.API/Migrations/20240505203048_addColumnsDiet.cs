using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dieta.API.Migrations
{
    /// <inheritdoc />
    public partial class addColumnsDiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Diets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "disabled_at",
                table: "Diets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Diets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "disabled_at",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Diets");
        }
    }
}
