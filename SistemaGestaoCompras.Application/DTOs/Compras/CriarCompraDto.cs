namespace SistemaGestaoCompras.Application.DTOs.Compras;

public class CriarCompraDto
{
    public Guid IdUsuario { get; set; }
    public Guid IdMercado { get; set; }
    public DateTime DataCompra { get; set; }
}