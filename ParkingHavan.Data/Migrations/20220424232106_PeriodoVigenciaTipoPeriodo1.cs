using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingHavan.Data.Migrations
{
    public partial class PeriodoVigenciaTipoPeriodo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeriodoVigenciaTipoPeriodo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TabelaPrecoPeriodoVigenciaId = table.Column<long>(type: "bigint", nullable: false),
                    TabelaPrecoTipoPeriodoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoVigenciaTipoPeriodo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodoVigenciaTipoPeriodo_TabelaPrecoPeriodoVigencia_TabelaPrecoPeriodoVigenciaId",
                        column: x => x.TabelaPrecoPeriodoVigenciaId,
                        principalTable: "TabelaPrecoPeriodoVigencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriodoVigenciaTipoPeriodo_TabelaPrecoTipoPeriodo_TabelaPrecoTipoPeriodoId",
                        column: x => x.TabelaPrecoTipoPeriodoId,
                        principalTable: "TabelaPrecoTipoPeriodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoVigenciaTipoPeriodo_TabelaPrecoPeriodoVigenciaId",
                table: "PeriodoVigenciaTipoPeriodo",
                column: "TabelaPrecoPeriodoVigenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoVigenciaTipoPeriodo_TabelaPrecoTipoPeriodoId",
                table: "PeriodoVigenciaTipoPeriodo",
                column: "TabelaPrecoTipoPeriodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodoVigenciaTipoPeriodo");
        }
    }
}
