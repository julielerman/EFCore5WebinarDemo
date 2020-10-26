using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLibrary.Migrations
{
    public partial class m2mpayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressPerson_Addresses_AddressesId",
                table: "AddressPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressPerson_People_ResidentsId",
                table: "AddressPerson");

            migrationBuilder.RenameColumn(
                name: "ResidentsId",
                table: "AddressPerson",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "AddressesId",
                table: "AddressPerson",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressPerson_ResidentsId",
                table: "AddressPerson",
                newName: "IX_AddressPerson_PersonId");

            migrationBuilder.AddColumn<DateTime>(
                name: "MovedInDate",
                table: "AddressPerson",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressPerson_Addresses_AddressId",
                table: "AddressPerson",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressPerson_People_PersonId",
                table: "AddressPerson",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressPerson_Addresses_AddressId",
                table: "AddressPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressPerson_People_PersonId",
                table: "AddressPerson");

            migrationBuilder.DropColumn(
                name: "MovedInDate",
                table: "AddressPerson");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "AddressPerson",
                newName: "ResidentsId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "AddressPerson",
                newName: "AddressesId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressPerson_PersonId",
                table: "AddressPerson",
                newName: "IX_AddressPerson_ResidentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressPerson_Addresses_AddressesId",
                table: "AddressPerson",
                column: "AddressesId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressPerson_People_ResidentsId",
                table: "AddressPerson",
                column: "ResidentsId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
