namespace SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
public class AdicionarItemListaDto
{
    public Guid IdListaDeCompras { get; set; }
    public Guid IdProduto { get; set; }
    public decimal QuantidadePlanejada { get; set; }
    public string Unidade { get; set; } = string.Empty;
}