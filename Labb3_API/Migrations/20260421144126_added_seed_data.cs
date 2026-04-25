using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class added_seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Konsten att bygga logik med C# och .NET.", "Programmering" },
                    { 2, "Allt från snabba pister till pudersnö i Alperna.", "Skidåkning" },
                    { 3, "Experimenterande i köket med smaker från hela världen.", "Matlagning" },
                    { 4, "Träning och tävling inom agility, lydnad och sök.", "Hundsport" },
                    { 5, "Konsten att fånga ljus och ögonblick med digital systemkamera.", "Fotografering" },
                    { 6, "Strategiska sällskapsspel, från enkla klassiker till tunga Euro-games.", "Brädspel" },
                    { 7, "Allt från styrkelyft på gymmet till löpning i skogen.", "Träning" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Anna Andersson", 701234567 },
                    { 2, "Björn Berg", 739876543 },
                    { 3, "Cecilia Ceder", 700112233 },
                    { 4, "Daniel Duva", 763425138 },
                    { 5, "Erik Ek", 765554433 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "InterestId", "PersonId", "Url" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://learn.microsoft.com/dotnet" },
                    { 2, 2, 1, "https://www.skistar.com" },
                    { 3, 1, 2, "https://stackoverflow.com" },
                    { 4, 3, 2, "https://www.tasteline.com" },
                    { 5, 1, 3, "https://www.github.com" },
                    { 6, 5, 3, "https://www.dpreview.com" },
                    { 7, 7, 3, "https://www.styrkelabbet.se" },
                    { 8, 4, 4, "https://www.skk.se" },
                    { 9, 6, 4, "https://boardgamegeek.com" },
                    { 10, 1, 5, "https://www.codewars.com" },
                    { 11, 7, 5, "https://www.runnersworld.se" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
