using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingHavan.Data.Migrations
{
    public partial class mudanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estacionamento_Cliente_ClienteId",
                table: "Estacionamento");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Estacionamento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Estacionamento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estacionamento_Cliente_ClienteId",
                table: "Estacionamento",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estacionamento_Cliente_ClienteId",
                table: "Estacionamento");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Estacionamento");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Estacionamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estacionamento_Cliente_ClienteId",
                table: "Estacionamento",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
