using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.DTOs.Compras;

public class AdicionarItemCompraDto
{
    public Guid IdCompra { get; set; }
    public Guid IdProduto { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public decimal Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public UnidadeMedida Unidade { get; set; } = null!;
}