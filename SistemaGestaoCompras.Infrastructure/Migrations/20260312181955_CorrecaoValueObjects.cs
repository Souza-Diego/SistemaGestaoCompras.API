using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestaoCompras.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco_Valor",
                table: "RegistrosDePreco",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "ValorPlanejado_Valor",
                table: "Orcamentos",
                newName: "ValorPlanejado");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario_Valor",
                table: "ItensCompra",
                newName: "PrecoUnitario");

            migrationBuilder.RenameColumn(
                name: "ValorTotal_Valor",
                table: "Compras",
                newName: "ValorTotal");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UnidadeReferencia_FatorBase",
                table: "RegistrosDePreco",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeReferencia_Nome",
                table: "RegistrosDePreco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnidadeReferencia_Simbolo",
                table: "RegistrosDePreco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnidadeReferencia_Tipo",
                table: "RegistrosDePreco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnidadeBase_FatorBase",
                table: "Produtos",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeBase_Nome",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnidadeBase_Simbolo",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnidadeBase_Tipo",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Unidade_FatorBase",
                table: "ItensListas",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Unidade_Nome",
                table: "ItensListas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unidade_Simbolo",
                table: "ItensListas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Unidade_Tipo",
                table: "ItensListas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Unidade_FatorBase",
                table: "ItensListaPadrao",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Unidade_Nome",
                table: "ItensListaPadrao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unidade_Simbolo",
                table: "ItensListaPadrao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Unidade_Tipo",
                table: "ItensListaPadrao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Unidade_FatorBase",
                table: "ItensCompra",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Unidade_Nome",
                table: "ItensCompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unidade_Simbolo",
                table: "ItensCompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Unidade_Tipo",
                table: "ItensCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UnidadeReferencia_FatorBase",
                table: "RegistrosDePreco");

            migrationBuilder.DropColumn(
                name: "UnidadeReferencia_Nome",
                table: "RegistrosDePreco");

            migrationBuilder.DropColumn(
                name: "UnidadeReferencia_Simbolo",
                table: "RegistrosDePreco");

            migrationBuilder.DropColumn(
                name: "UnidadeReferencia_Tipo",
                table: "RegistrosDePreco");

            migrationBuilder.DropColumn(
                name: "UnidadeBase_FatorBase",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UnidadeBase_Nome",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UnidadeBase_Simbolo",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UnidadeBase_Tipo",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Unidade_FatorBase",
                table: "ItensListas");

            migrationBuilder.DropColumn(
                name: "Unidade_Nome",
                table: "ItensListas");

            migrationBuilder.DropColumn(
                name: "Unidade_Simbolo",
                table: "ItensListas");

            migrationBuilder.DropColumn(
                name: "Unidade_Tipo",
                table: "ItensListas");

            migrationBuilder.DropColumn(
                name: "Unidade_FatorBase",
                table: "ItensListaPadrao");

            migrationBuilder.DropColumn(
                name: "Unidade_Nome",
                table: "ItensListaPadrao");

            migrationBuilder.DropColumn(
                name: "Unidade_Simbolo",
                table: "ItensListaPadrao");

            migrationBuilder.DropColumn(
                name: "Unidade_Tipo",
                table: "ItensListaPadrao");

            migrationBuilder.DropColumn(
                name: "Unidade_FatorBase",
                table: "ItensCompra");

            migrationBuilder.DropColumn(
                name: "Unidade_Nome",
                table: "ItensCompra");

            migrationBuilder.DropColumn(
                name: "Unidade_Simbolo",
                table: "ItensCompra");

            migrationBuilder.DropColumn(
                name: "Unidade_Tipo",
                table: "ItensCompra");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "RegistrosDePreco",
                newName: "Preco_Valor");

            migrationBuilder.RenameColumn(
                name: "ValorPlanejado",
                table: "Orcamentos",
                newName: "ValorPlanejado_Valor");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "ItensCompra",
                newName: "PrecoUnitario_Valor");

            migrationBuilder.RenameColumn(
                name: "ValorTotal",
                table: "Compras",
                newName: "ValorTotal_Valor");
        }
    }
}
