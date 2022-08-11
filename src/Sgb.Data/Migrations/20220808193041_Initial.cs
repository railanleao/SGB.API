using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sgb.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compradores",
                columns: table => new
                {
                    CadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar", unicode: false, maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "varchar", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compradores", x => x.CadastroId);
                });

            migrationBuilder.CreateTable(
                name: "Associados",
                columns: table => new
                {
                    CadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fazenda = table.Column<string>(type: "varchar", unicode: false, maxLength: 180, nullable: false),
                    DataDaParceria = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    IdComprador = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar", unicode: false, maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "varchar", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associados", x => x.CadastroId);
                    table.ForeignKey(
                        name: "FK_Associados_Compradores_IdComprador",
                        column: x => x.IdComprador,
                        principalTable: "Compradores",
                        principalColumn: "CadastroId");
                });

            migrationBuilder.CreateTable(
                name: "Parcerias",
                columns: table => new
                {
                    BoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdComprador = table.Column<Guid>(type: "uuid", nullable: false),
                    IdAssociado = table.Column<Guid>(type: "uuid", nullable: false),
                    DataInicioParceria = table.Column<DateTime>(type: "date", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Origem = table.Column<string>(type: "varchar", unicode: false, maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Lote = table.Column<string>(type: "varchar", unicode: false, maxLength: 10, nullable: false),
                    Classificacao = table.Column<string>(type: "text", nullable: false),
                    CompraVenda = table.Column<string>(type: "text", nullable: false),
                    PesoBruto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RendimentoCarcaca = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Arroba = table.Column<decimal>(type: "numeric(18,2)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcerias", x => x.BoiId);
                    table.ForeignKey(
                        name: "FK_Parcerias_Associados_IdAssociado",
                        column: x => x.IdAssociado,
                        principalTable: "Associados",
                        principalColumn: "CadastroId");
                    table.ForeignKey(
                        name: "FK_Parcerias_Compradores_IdComprador",
                        column: x => x.IdComprador,
                        principalTable: "Compradores",
                        principalColumn: "CadastroId");
                });

            migrationBuilder.CreateTable(
                name: "Saidas",
                columns: table => new
                {
                    BoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    PesoMedioAlterado = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Saida = table.Column<DateTime>(type: "date", nullable: false),
                    IdComprador = table.Column<Guid>(type: "uuid", nullable: false),
                    IdAssociado = table.Column<Guid>(type: "uuid", nullable: false),
                    InicioParceriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Classificacao = table.Column<string>(type: "text", nullable: true),
                    CompraVenda = table.Column<string>(type: "text", nullable: true),
                    PesoBruto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RendimentoCarcaca = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Arroba = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saidas", x => x.BoiId);
                    table.ForeignKey(
                        name: "FK_Saidas_Associados_IdAssociado",
                        column: x => x.IdAssociado,
                        principalTable: "Associados",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Saidas_Compradores_IdComprador",
                        column: x => x.IdComprador,
                        principalTable: "Compradores",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Saidas_Parcerias_InicioParceriaId",
                        column: x => x.InicioParceriaId,
                        principalTable: "Parcerias",
                        principalColumn: "BoiId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Associados_IdComprador",
                table: "Associados",
                column: "IdComprador");

            migrationBuilder.CreateIndex(
                name: "IX_Parcerias_IdAssociado",
                table: "Parcerias",
                column: "IdAssociado");

            migrationBuilder.CreateIndex(
                name: "IX_Parcerias_IdComprador",
                table: "Parcerias",
                column: "IdComprador");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_IdAssociado",
                table: "Saidas",
                column: "IdAssociado");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_IdComprador",
                table: "Saidas",
                column: "IdComprador");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_InicioParceriaId",
                table: "Saidas",
                column: "InicioParceriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saidas");

            migrationBuilder.DropTable(
                name: "Parcerias");

            migrationBuilder.DropTable(
                name: "Associados");

            migrationBuilder.DropTable(
                name: "Compradores");
        }
    }
}
