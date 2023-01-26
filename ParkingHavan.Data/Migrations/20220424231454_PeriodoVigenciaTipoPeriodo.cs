using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingHavan.Data.Migrations
{
    public partial class PeriodoVigenciaTipoPeriodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia");

            migrationBuilder.DropIndex(
                name: "IX_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia");

            migrationBuilder.DropColumn(
                name: "TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                column: "TabelaPrecoTipoPeriodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                column: "TabelaPrecoTipoPeriodoId",
                principalTable: "TabelaPrecoTipoPeriodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
