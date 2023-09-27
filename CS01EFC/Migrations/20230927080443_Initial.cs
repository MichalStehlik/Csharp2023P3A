using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CS01EFC.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistMovies",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ArtistId1 = table.Column<int>(type: "int", nullable: true),
                    MovieId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMovies", x => new { x.MovieId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_ArtistMovies_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistMovies_Artists_ArtistId1",
                        column: x => x.ArtistId1,
                        principalTable: "Artists",
                        principalColumn: "ArtistId");
                    table.ForeignKey(
                        name: "FK_ArtistMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistMovies_Movies_MovieId1",
                        column: x => x.MovieId1,
                        principalTable: "Movies",
                        principalColumn: "MovieId");
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "FirstName", "Gender", "LastName", "WebAddress" },
                values: new object[,]
                {
                    { 1, "Keanu", 1, "Reeves", "https://www.imdb.com/name/nm0000206/" },
                    { 2, "Timothée", 1, "Chalamet", null },
                    { 3, null, 2, "Zendaya", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Sci-fi" },
                    { 2, "Horror" },
                    { 3, "Životopis" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Duration", "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, 3f, 1, "Dune" },
                    { 2, 2.5f, 3, "Oppenheimer" }
                });

            migrationBuilder.InsertData(
                table: "ArtistMovies",
                columns: new[] { "ArtistId", "MovieId", "ArtistId1", "MovieId1" },
                values: new object[] { 3, 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMovies_ArtistId",
                table: "ArtistMovies",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMovies_ArtistId1",
                table: "ArtistMovies",
                column: "ArtistId1");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMovies_MovieId1",
                table: "ArtistMovies",
                column: "MovieId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistMovies");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
