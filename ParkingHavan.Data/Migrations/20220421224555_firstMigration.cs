using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingHavan.Data.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacaCarro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaPrecoTipoPeriodo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    HorarioInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFinal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPrecoTipoPeriodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaPrecoValores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<int>(type: "int", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPrecoValores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    HorarioInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPagamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estacionamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabelaPrecoPeriodoVigencia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TabelaPeriodoId = table.Column<long>(type: "bigint", nullable: false),
                    TipoPeriodoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPrecoPeriodoVigencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaPrecoPeriodoVigencia_TabelaPrecoTipoPeriodo_TipoPeriodoId",
                        column: x => x.TipoPeriodoId,
                        principalTable: "TabelaPrecoTipoPeriodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamento_ClienteId",
                table: "Estacionamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaPrecoPeriodoVigencia_TipoPeriodoId",
                table: "TabelaPrecoPeriodoVigencia",
                column: "TipoPeriodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estacionamento");

            migrationBuilder.DropTable(
                name: "TabelaPrecoPeriodoVigencia");

            migrationBuilder.DropTable(
                name: "TabelaPrecoValores");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TabelaPrecoTipoPeriodo");
        }
    }
}
