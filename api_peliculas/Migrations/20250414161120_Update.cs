using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_peliculas.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Categoría_CategoríaId",
                table: "Pelicula");

            migrationBuilder.RenameColumn(
                name: "CategoríaId",
                table: "Pelicula",
                newName: "Categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Pelicula_CategoríaId",
                table: "Pelicula",
                newName: "IX_Pelicula_Categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Categoría_Categoria",
                table: "Pelicula",
                column: "Categoria",
                principalTable: "Categoría",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Categoría_Categoria",
                table: "Pelicula");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Pelicula",
                newName: "CategoríaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pelicula_Categoria",
                table: "Pelicula",
                newName: "IX_Pelicula_CategoríaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Categoría_CategoríaId",
                table: "Pelicula",
                column: "CategoríaId",
                principalTable: "Categoría",
                principalColumn: "Id");
        }
    }
}
