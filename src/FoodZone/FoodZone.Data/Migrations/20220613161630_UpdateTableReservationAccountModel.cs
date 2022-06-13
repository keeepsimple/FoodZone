using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodZone.Data.Migrations
{
    public partial class UpdateTableReservationAccountModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tables_TableId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TableId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                schema: "common",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ReservationId",
                schema: "common",
                table: "Tables",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Reservations_ReservationId",
                schema: "common",
                table: "Tables",
                column: "ReservationId",
                principalSchema: "common",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Reservations_ReservationId",
                schema: "common",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_ReservationId",
                schema: "common",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                schema: "common",
                table: "Tables");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TableId",
                table: "AspNetUsers",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tables_TableId",
                table: "AspNetUsers",
                column: "TableId",
                principalSchema: "common",
                principalTable: "Tables",
                principalColumn: "Id");
        }
    }
}
