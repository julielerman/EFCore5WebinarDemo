using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLibrary.Migrations
{
    public partial class m2m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WildlifeSightings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WildlifeSightings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WildlifeSightings_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressPerson",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    ResidentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressPerson", x => new { x.AddressesId, x.ResidentsId });
                    table.ForeignKey(
                        name: "FK_AddressPerson_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressPerson_People_ResidentsId",
                        column: x => x.ResidentsId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "11111", "1 Main" },
                    { 2, "22222", "2 Main" },
                    { 3, "3333", "3 Main" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Julie", "Lerman" },
                    { 2, "Husband of", "Julie" },
                    { 3, "Brice", "Lambson" },
                    { 4, "Arthur", "Vickers" }
                });

            migrationBuilder.InsertData(
                table: "WildlifeSightings",
                columns: new[] { "Id", "AddressId", "DateTime", "Description", "Discriminator" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bear", "WildlifeSighting" },
                    { 2, 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bear Cub #1", "WildlifeSighting" },
                    { 3, 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bear Cub #2", "WildlifeSighting" },
                    { 4, 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bear Cub #3", "WildlifeSighting" },
                    { 5, 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Squirrel", "WildlifeSighting" },
                    { 6, 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garter Snake", "WildlifeSighting" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressPerson_ResidentsId",
                table: "AddressPerson",
                column: "ResidentsId");

            migrationBuilder.CreateIndex(
                name: "IX_WildlifeSightings_AddressId",
                table: "WildlifeSightings",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressPerson");

            migrationBuilder.DropTable(
                name: "WildlifeSightings");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
