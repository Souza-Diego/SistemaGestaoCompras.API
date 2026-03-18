using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestaoCompras.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Ajustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItensListas_IdProduto",
                table: "ItensListas",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensListas_Produtos_IdProduto",
                table: "ItensListas",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensListas_Produtos_IdProduto",
                table: "ItensListas");

            migrationBuilder.DropIndex(
                name: "IX_ItensListas_IdProduto",
                table: "ItensListas");
        }
    }
}
