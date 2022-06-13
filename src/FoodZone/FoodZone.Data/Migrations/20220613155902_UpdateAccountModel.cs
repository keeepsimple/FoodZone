using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodZone.Data.Migrations
{
    public partial class UpdateAccountModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tables_TableId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tables_TableId",
                table: "AspNetUsers",
                column: "TableId",
                principalSchema: "common",
                principalTable: "Tables",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tables_TableId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tables_TableId",
                table: "AspNetUsers",
                column: "TableId",
                principalSchema: "common",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
