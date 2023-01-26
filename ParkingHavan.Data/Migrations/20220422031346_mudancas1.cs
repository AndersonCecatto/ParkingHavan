using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingHavan.Data.Migrations
{
    public partial class mudancas1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia");

            migrationBuilder.RenameColumn(
                name: "TipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                newName: "TabelaPrecoTipoPeriodoId");

            migrationBuilder.RenameIndex(
                name: "IX_TabelaPrecoPeriodoVigencia_TipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                newName: "IX_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                column: "TabelaPrecoTipoPeriodoId",
                principalTable: "TabelaPrecoTipoPeriodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia");

            migrationBuilder.RenameColumn(
                name: "TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                newName: "TipoPeriodoId");

            migrationBuilder.RenameIndex(
                name: "IX_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                newName: "IX_TabelaPrecoPeriodoVigencia_TipoPeriodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                column: "TipoPeriodoId",
                principalTable: "TabelaPrecoTipoPeriodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
