using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingHavan.Data.Migrations
{
    public partial class mudancas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia");

            migrationBuilder.DropColumn(
                name: "TabelaPeriodoId",
                table: "TabelaPrecoPeriodoVigencia");

            migrationBuilder.AlterColumn<long>(
                name: "TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                column: "TabelaPrecoTipoPeriodoId",
                principalTable: "TabelaPrecoTipoPeriodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia");

            migrationBuilder.AlterColumn<long>(
                name: "TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "TabelaPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                column: "TabelaPrecoTipoPeriodoId",
                principalTable: "TabelaPrecoTipoPeriodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
