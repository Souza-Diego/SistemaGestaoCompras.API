using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestaoCompras.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMercado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinalizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Finalizada = table.Column<bool>(type: "bit", nullable: false),
                    AtivaParaRelatorio = table.Column<bool>(type: "bit", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConvitesGrupo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGrupo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCriadoPorUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvitesGrupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCriadoPorUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListasDeCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdGrupo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasDeCompra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListasDeCompraPadrao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasDeCompraPadrao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    ValorPlanejado = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMarca = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnidadeBase_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadeBase_Simbolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadeBase_Tipo = table.Column<int>(type: "int", nullable: false),
                    UnidadeBase_FatorBase = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    IdCriadoPorUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    QuantidadeBase = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosDePreco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMercado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    QuantidadeReferencia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnidadeReferencia_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadeReferencia_Simbolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadeReferencia_Tipo = table.Column<int>(type: "int", nullable: false),
                    UnidadeReferencia_FatorBase = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosDePreco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plano = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCompra = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeProdutoSnapshot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Unidade_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidade_Simbolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidade_Tipo = table.Column<int>(type: "int", nullable: false),
                    Unidade_FatorBase = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCompra_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensListaPadrao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdListaDeComprasPadrao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadePlanejada = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Unidade_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidade_Simbolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidade_Tipo = table.Column<int>(type: "int", nullable: false),
                    Unidade_FatorBase = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensListaPadrao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensListaPadrao_ListasDeCompraPadrao_IdListaDeComprasPadrao",
                        column: x => x.IdListaDeComprasPadrao,
                        principalTable: "ListasDeCompraPadrao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensListas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdListaDeCompras = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadePlanejada = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Unidade_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidade_Simbolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidade_Tipo = table.Column<int>(type: "int", nullable: false),
                    Unidade_FatorBase = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensListas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensListas_ListasDeCompra_IdListaDeCompras",
                        column: x => x.IdListaDeCompras,
                        principalTable: "ListasDeCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensListas_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupoUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGrupo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Papel = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoUsuarios_Grupos_IdGrupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoUsuarios_IdGrupo",
                table: "GrupoUsuarios",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoUsuarios_IdUsuario_IdGrupo",
                table: "GrupoUsuarios",
                columns: new[] { "IdUsuario", "IdGrupo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompra_IdCompra",
                table: "ItensCompra",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItensListaPadrao_IdListaDeComprasPadrao",
                table: "ItensListaPadrao",
                column: "IdListaDeComprasPadrao");

            migrationBuilder.CreateIndex(
                name: "IX_ItensListas_IdListaDeCompras",
                table: "ItensListas",
                column: "IdListaDeCompras");

            migrationBuilder.CreateIndex(
                name: "IX_ItensListas_IdProduto",
                table: "ItensListas",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_IdUsuario_Ano_Mes",
                table: "Orcamentos",
                columns: new[] { "IdUsuario", "Ano", "Mes" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDePreco_IdProduto_IdMercado_DataRegistro",
                table: "RegistrosDePreco",
                columns: new[] { "IdProduto", "IdMercado", "DataRegistro" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ConvitesGrupo");

            migrationBuilder.DropTable(
                name: "GrupoUsuarios");

            migrationBuilder.DropTable(
                name: "ItensCompra");

            migrationBuilder.DropTable(
                name: "ItensListaPadrao");

            migrationBuilder.DropTable(
                name: "ItensListas");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Orcamentos");

            migrationBuilder.DropTable(
                name: "RegistrosDePreco");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "ListasDeCompraPadrao");

            migrationBuilder.DropTable(
                name: "ListasDeCompra");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
