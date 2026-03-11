namespace SistemaGestaoCompras.Application.DTOs.ListasPadrao
{
    public class AlterarQuantidadeItemListaPadraoDto
    {
        public Guid IdListaPadrao { get; set; }
        public Guid IdProduto { get; set; }
        public decimal NovaQuantidade { get; set; }
    }
}