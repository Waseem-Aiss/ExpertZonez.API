using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpertZonez.API.Migrations
{
    /// <inheritdoc />
    public partial class GenreTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceGenres_genreId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Services",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_genreId",
                table: "Services",
                newName: "IX_Services_GenreId");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "ServiceGenres",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceGenres_GenreId",
                table: "Services",
                column: "GenreId",
                principalTable: "ServiceGenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceGenres_GenreId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Services",
                newName: "genreId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_GenreId",
                table: "Services",
                newName: "IX_Services_genreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ServiceGenres",
                newName: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceGenres_genreId",
                table: "Services",
                column: "genreId",
                principalTable: "ServiceGenres",
                principalColumn: "genreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
