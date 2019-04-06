using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzaria.Infra.Data.Migrations
{
    public partial class AlteracaoBancoTeste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_TamanhosPizza_TamanhoPizzaId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "TamanhoPizzaId",
                table: "Pedidos",
                newName: "TamanhosPizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_TamanhoPizzaId",
                table: "Pedidos",
                newName: "IX_Pedidos_TamanhosPizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_TamanhosPizza_TamanhosPizzaId",
                table: "Pedidos",
                column: "TamanhosPizzaId",
                principalTable: "TamanhosPizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_TamanhosPizza_TamanhosPizzaId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "TamanhosPizzaId",
                table: "Pedidos",
                newName: "TamanhoPizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_TamanhosPizzaId",
                table: "Pedidos",
                newName: "IX_Pedidos_TamanhoPizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_TamanhosPizza_TamanhoPizzaId",
                table: "Pedidos",
                column: "TamanhoPizzaId",
                principalTable: "TamanhosPizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
