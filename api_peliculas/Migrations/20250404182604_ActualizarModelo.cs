using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_peliculas.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorías",
                table: "Categorías");

            migrationBuilder.RenameTable(
                name: "Categorías",
                newName: "Categoría");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoría",
                table: "Categoría",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoría",
                table: "Categoría");

            migrationBuilder.RenameTable(
                name: "Categoría",
                newName: "Categorías");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorías",
                table: "Categorías",
                column: "Id");
        }
    }
}
