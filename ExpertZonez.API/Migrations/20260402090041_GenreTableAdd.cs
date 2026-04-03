using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpertZonez.API.Migrations
{
    /// <inheritdoc />
    public partial class GenreTableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "genreId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiceGenres",
                columns: table => new
                {
                    genreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceGenres", x => x.genreId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_genreId",
                table: "Services",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceGenres_genreId",
                table: "Services",
                column: "genreId",
                principalTable: "ServiceGenres",
                principalColumn: "genreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceGenres_genreId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ServiceGenres");

            migrationBuilder.DropIndex(
                name: "IX_Services_genreId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "genreId",
                table: "Services");
        }
    }
}
