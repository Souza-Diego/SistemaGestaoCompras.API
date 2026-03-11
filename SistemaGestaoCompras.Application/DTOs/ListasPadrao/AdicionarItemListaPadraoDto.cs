namespace SistemaGestaoCompras.Application.DTOs.ListasPadrao
{
    public class AdicionarItemListaPadraoDto
    {
        public Guid IdListaPadrao { get; set; }
        public Guid IdProduto { get; set; }
        public decimal QuantidadePlanejada { get; set; }
        public string Unidade { get; set; } = string.Empty;
    }
}