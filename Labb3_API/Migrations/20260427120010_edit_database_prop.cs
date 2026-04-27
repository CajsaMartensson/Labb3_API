using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class edit_database_prop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Interests_InterestId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Interests_InterestId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_InterestId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Links_InterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Links",
                newName: "InterestPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                newName: "IX_Links_InterestPersonId");

            migrationBuilder.CreateTable(
                name: "InterestPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterestPersons_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InterestPersons",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 1, 2 },
                    { 4, 3, 2 },
                    { 5, 1, 3 },
                    { 6, 5, 3 },
                    { 7, 7, 3 },
                    { 8, 4, 4 },
                    { 9, 6, 4 },
                    { 10, 1, 5 },
                    { 11, 7, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                column: "InterestPersonId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                column: "InterestPersonId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                column: "InterestPersonId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                column: "InterestPersonId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                column: "InterestPersonId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                column: "InterestPersonId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8,
                column: "InterestPersonId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9,
                column: "InterestPersonId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10,
                column: "InterestPersonId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 11,
                column: "InterestPersonId",
                value: 11);

            migrationBuilder.CreateIndex(
                name: "IX_InterestPersons_InterestId",
                table: "InterestPersons",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPersons_PersonId",
                table: "InterestPersons",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_InterestPersons_InterestPersonId",
                table: "Links",
                column: "InterestPersonId",
                principalTable: "InterestPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_InterestPersons_InterestPersonId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "InterestPersons");

            migrationBuilder.RenameColumn(
                name: "InterestPersonId",
                table: "Links",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_InterestPersonId",
                table: "Links",
                newName: "IX_Links_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1,
                column: "InterestId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 7, 3 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 6, 4 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 1, 5 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 7, 5 });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "InterestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "InterestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                column: "InterestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4,
                column: "InterestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5,
                column: "InterestId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_InterestId",
                table: "Persons",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Interests_InterestId",
                table: "Links",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Interests_InterestId",
                table: "Persons",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id");
        }
    }
}
