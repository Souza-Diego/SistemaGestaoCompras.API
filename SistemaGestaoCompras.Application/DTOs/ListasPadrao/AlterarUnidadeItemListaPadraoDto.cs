namespace SistemaGestaoCompras.Application.DTOs.ListasPadrao
{
    public class AlterarUnidadeItemListaPadraoDto
    {
        public Guid IdListaPadrao { get; set; }
        public Guid IdProduto { get; set; }
        public string NovaUnidade { get; set; } = string.Empty;
    }
}