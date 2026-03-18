namespace SistemaGestaoCompras.Application.DTOs.ListaDeCompras
{
    public class ItemListaDetalhadoDto
    {
        public Guid IdProduto { get; set; }
        public string NomeProduto { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public decimal Quantidade { get; set; }
        public string Unidade { get; set; } = null!;
        public decimal? MelhorPreco { get; set; }
        public string? Mercado { get; set; }
        public decimal? PrecoTotal { get; set; }
    }
}