using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sgb.Data.Migrations
{
    public partial class addColumnQtddSaida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Parcerias",
                newName: "QtdadeEntrada");

            migrationBuilder.AddColumn<int>(
                name: "QtdadeSaida",
                table: "Saidas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdadeSaida",
                table: "Saidas");

            migrationBuilder.RenameColumn(
                name: "QtdadeEntrada",
                table: "Parcerias",
                newName: "Quantidade");
        }
    }
}
