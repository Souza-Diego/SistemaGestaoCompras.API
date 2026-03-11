namespace SistemaGestaoCompras.Application.DTOs.Compras;

public class ListarComprasPeriodoDto
{
    public Guid IdUsuario { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}