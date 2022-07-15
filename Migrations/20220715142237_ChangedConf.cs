using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTaskApp.Migrations
{
    public partial class ChangedConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons");

            migrationBuilder.AddColumn<long>(
                name: "AddressId1",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId1",
                table: "Persons",
                column: "AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressId1",
                table: "Persons",
                column: "AddressId1",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AddressId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "Persons");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
