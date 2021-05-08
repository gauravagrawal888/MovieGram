using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieGram.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "MovieShowTimes",
                columns: table => new
                {
                    MovieShowtimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShowTimes", x => x.MovieShowtimeId);
                    table.ForeignKey(
                        name: "FK_MovieShowTimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Description", "Director", "Genre", "Language", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Events escalate from weird to terrifying as they contend with the house's batty owner, her imposing son, a moody Swedish lepidopterist, a pedantic English professor, an extraordinarily rare butterfly, the world's best blueberry muffins, a .44 Magnum, a demented serial killer, and one very strict rulebook.", "D.W.Young", "Suspense", "English", new DateTime(2021, 5, 8, 17, 10, 9, 425, DateTimeKind.Local).AddTicks(2015), "The Happy House" },
                    { 2, "When corpses drained of blood begin to show up in a European village, vampirism is suspected to be responsible.", "Frank R. Strayer", "Horror", "German", new DateTime(2021, 5, 11, 17, 10, 9, 426, DateTimeKind.Local).AddTicks(6298), "The Vampire Bat" },
                    { 3, "After several years playing NFL professional football, 25 year-old Kyle Bishop (Lance Gross) is released from his fourth team in three years. Kyle returns to his hometown, broke and at a complete loss about what he will do for a living. After an initially cold reception.", "Matthew A. Cherry", "Romance", "English", new DateTime(2021, 5, 14, 17, 10, 9, 426, DateTimeKind.Local).AddTicks(6402), "The Last Fall" },
                    { 4, "A travelling troupe of jousters and performers are slowly cracking under the pressure of hick cops, financial troubles and their failure to live up to their own ideals. The group's leader, King Billy, is increasingly unable to maintain his warrior's rule while the Black Knight is being tempted away to LA and stardom.", "George A. Romero", "Drama", "Swedish", new DateTime(2021, 5, 17, 17, 10, 9, 426, DateTimeKind.Local).AddTicks(6408), "Knightriders" }
                });

            migrationBuilder.InsertData(
                table: "MovieShowTimes",
                columns: new[] { "MovieShowtimeId", "MovieId", "Time" },
                values: new object[,]
                {
                    { 1, 1, "10:00" },
                    { 2, 1, "12:00" },
                    { 3, 1, "14:00" },
                    { 4, 1, "16:00" },
                    { 5, 2, "11:00" },
                    { 6, 2, "12:00" },
                    { 7, 2, "14:00" },
                    { 8, 2, "17:00" },
                    { 9, 3, "16:00" },
                    { 10, 3, "17:00" },
                    { 11, 3, "18:00" },
                    { 12, 3, "19:00" },
                    { 13, 4, "10:00" },
                    { 14, 4, "13:00" },
                    { 15, 4, "15:00" },
                    { 16, 4, "18:00" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowTimes_MovieId",
                table: "MovieShowTimes",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieShowTimes");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
