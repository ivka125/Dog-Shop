using Microsoft.EntityFrameworkCore.Migrations;

namespace ItCareer.Migrations
{
    public partial class CR_From_CRUD2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Owners_OwnerId",
                table: "Dogs");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Dogs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Owners_OwnerId",
                table: "Dogs",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Owners_OwnerId",
                table: "Dogs");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Dogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Owners_OwnerId",
                table: "Dogs",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
