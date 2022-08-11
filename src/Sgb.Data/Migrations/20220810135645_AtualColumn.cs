using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sgb.Data.Migrations
{
    public partial class AtualColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associados_Compradores_IdComprador",
                table: "Associados");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcerias_Associados_IdAssociado",
                table: "Parcerias");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcerias_Compradores_IdComprador",
                table: "Parcerias");

            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Associados_IdAssociado",
                table: "Saidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Compradores_IdComprador",
                table: "Saidas");

            migrationBuilder.RenameColumn(
                name: "IdComprador",
                table: "Saidas",
                newName: "CompradorId");

            migrationBuilder.RenameColumn(
                name: "IdAssociado",
                table: "Saidas",
                newName: "AssociadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Saidas_IdComprador",
                table: "Saidas",
                newName: "IX_Saidas_CompradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Saidas_IdAssociado",
                table: "Saidas",
                newName: "IX_Saidas_AssociadoId");

            migrationBuilder.RenameColumn(
                name: "IdComprador",
                table: "Parcerias",
                newName: "CompradorId");

            migrationBuilder.RenameColumn(
                name: "IdAssociado",
                table: "Parcerias",
                newName: "AssociadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcerias_IdComprador",
                table: "Parcerias",
                newName: "IX_Parcerias_CompradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcerias_IdAssociado",
                table: "Parcerias",
                newName: "IX_Parcerias_AssociadoId");

            migrationBuilder.RenameColumn(
                name: "IdComprador",
                table: "Associados",
                newName: "CompradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Associados_IdComprador",
                table: "Associados",
                newName: "IX_Associados_CompradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associados_Compradores_CompradorId",
                table: "Associados",
                column: "CompradorId",
                principalTable: "Compradores",
                principalColumn: "CadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcerias_Associados_AssociadoId",
                table: "Parcerias",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "CadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcerias_Compradores_CompradorId",
                table: "Parcerias",
                column: "CompradorId",
                principalTable: "Compradores",
                principalColumn: "CadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Associados_AssociadoId",
                table: "Saidas",
                column: "AssociadoId",
                principalTable: "Associados",
                principalColumn: "CadastroId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Compradores_CompradorId",
                table: "Saidas",
                column: "CompradorId",
                principalTable: "Compradores",
                principalColumn: "CadastroId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associados_Compradores_CompradorId",
                table: "Associados");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcerias_Associados_AssociadoId",
                table: "Parcerias");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcerias_Compradores_CompradorId",
                table: "Parcerias");

            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Associados_AssociadoId",
                table: "Saidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Compradores_CompradorId",
                table: "Saidas");

            migrationBuilder.RenameColumn(
                name: "CompradorId",
                table: "Saidas",
                newName: "IdComprador");

            migrationBuilder.RenameColumn(
                name: "AssociadoId",
                table: "Saidas",
                newName: "IdAssociado");

            migrationBuilder.RenameIndex(
                name: "IX_Saidas_CompradorId",
                table: "Saidas",
                newName: "IX_Saidas_IdComprador");

            migrationBuilder.RenameIndex(
                name: "IX_Saidas_AssociadoId",
                table: "Saidas",
                newName: "IX_Saidas_IdAssociado");

            migrationBuilder.RenameColumn(
                name: "CompradorId",
                table: "Parcerias",
                newName: "IdComprador");

            migrationBuilder.RenameColumn(
                name: "AssociadoId",
                table: "Parcerias",
                newName: "IdAssociado");

            migrationBuilder.RenameIndex(
                name: "IX_Parcerias_CompradorId",
                table: "Parcerias",
                newName: "IX_Parcerias_IdComprador");

            migrationBuilder.RenameIndex(
                name: "IX_Parcerias_AssociadoId",
                table: "Parcerias",
                newName: "IX_Parcerias_IdAssociado");

            migrationBuilder.RenameColumn(
                name: "CompradorId",
                table: "Associados",
                newName: "IdComprador");

            migrationBuilder.RenameIndex(
                name: "IX_Associados_CompradorId",
                table: "Associados",
                newName: "IX_Associados_IdComprador");

            migrationBuilder.AddForeignKey(
                name: "FK_Associados_Compradores_IdComprador",
                table: "Associados",
                column: "IdComprador",
                principalTable: "Compradores",
                principalColumn: "CadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcerias_Associados_IdAssociado",
                table: "Parcerias",
                column: "IdAssociado",
                principalTable: "Associados",
                principalColumn: "CadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcerias_Compradores_IdComprador",
                table: "Parcerias",
                column: "IdComprador",
                principalTable: "Compradores",
                principalColumn: "CadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Associados_IdAssociado",
                table: "Saidas",
                column: "IdAssociado",
                principalTable: "Associados",
                principalColumn: "CadastroId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Compradores_IdComprador",
                table: "Saidas",
                column: "IdComprador",
                principalTable: "Compradores",
                principalColumn: "CadastroId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
