using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptAPet.Api.Migrations
{
    public partial class PetTableTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_TypeId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Pets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_TypeId",
                table: "Pets",
                column: "TypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_TypeId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Pets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_TypeId",
                table: "Pets",
                column: "TypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
