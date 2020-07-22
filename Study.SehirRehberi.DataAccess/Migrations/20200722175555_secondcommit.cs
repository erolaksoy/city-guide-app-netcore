using Microsoft.EntityFrameworkCore.Migrations;

namespace Study.SehirRehberi.DataAccess.Migrations
{
    public partial class secondcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Users_UserId",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Users_UserId",
                table: "Cities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Users_UserId",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Users_UserId",
                table: "Cities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
