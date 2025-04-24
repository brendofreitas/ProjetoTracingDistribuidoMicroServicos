using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Deposito.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacaoEstoque_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "Preco", "Quantidade" },
                values: new object[,]
                {
                    { 1, "Produto 1", 5.25m, 0 },
                    { 2, "Produto 2", 10.5m, 0 },
                    { 3, "Produto 3", 15.75m, 0 },
                    { 4, "Produto 4", 21m, 0 },
                    { 5, "Produto 5", 26.25m, 0 },
                    { 6, "Produto 6", 31.5m, 0 },
                    { 7, "Produto 7", 36.75m, 0 },
                    { 8, "Produto 8", 42m, 0 },
                    { 9, "Produto 9", 47.25m, 0 },
                    { 10, "Produto 10", 52.5m, 0 },
                    { 11, "Produto 11", 57.75m, 0 },
                    { 12, "Produto 12", 63m, 0 },
                    { 13, "Produto 13", 68.25m, 0 },
                    { 14, "Produto 14", 73.5m, 0 },
                    { 15, "Produto 15", 78.75m, 0 },
                    { 16, "Produto 16", 84m, 0 },
                    { 17, "Produto 17", 89.25m, 0 },
                    { 18, "Produto 18", 94.5m, 0 },
                    { 19, "Produto 19", 99.75m, 0 },
                    { 20, "Produto 20", 105m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEstoque_ProdutoId",
                table: "MovimentacaoEstoque",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacaoEstoque");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
