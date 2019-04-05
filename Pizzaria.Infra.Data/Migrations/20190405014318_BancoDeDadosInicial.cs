using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzaria.Infra.Data.Migrations
{
    public partial class BancoDeDadosInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdicionaisPizza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adicional = table.Column<string>(maxLength: 150, nullable: false),
                    Valor = table.Column<decimal>(nullable: true),
                    Tempo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdicionaisPizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaboresPizza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sabor = table.Column<string>(maxLength: 200, nullable: false),
                    TempoAdicional = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaboresPizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TamanhosPizza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tamanho = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Tempo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamanhosPizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaboresPizzaId = table.Column<int>(nullable: false),
                    TamanhoPizzaId = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Tempo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_SaboresPizza_SaboresPizzaId",
                        column: x => x.SaboresPizzaId,
                        principalTable: "SaboresPizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_TamanhosPizza_TamanhoPizzaId",
                        column: x => x.TamanhoPizzaId,
                        principalTable: "TamanhosPizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdicionaisPedido",
                columns: table => new
                {
                    PedidosId = table.Column<int>(nullable: false),
                    AdicionaisPizzaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdicionaisPedido", x => new { x.PedidosId, x.AdicionaisPizzaId });
                    table.ForeignKey(
                        name: "FK_AdicionaisPedido_AdicionaisPizza_AdicionaisPizzaId",
                        column: x => x.AdicionaisPizzaId,
                        principalTable: "AdicionaisPizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdicionaisPedido_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdicionaisPedido_AdicionaisPizzaId",
                table: "AdicionaisPedido",
                column: "AdicionaisPizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SaboresPizzaId",
                table: "Pedidos",
                column: "SaboresPizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TamanhoPizzaId",
                table: "Pedidos",
                column: "TamanhoPizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdicionaisPedido");

            migrationBuilder.DropTable(
                name: "AdicionaisPizza");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "SaboresPizza");

            migrationBuilder.DropTable(
                name: "TamanhosPizza");
        }
    }
}
