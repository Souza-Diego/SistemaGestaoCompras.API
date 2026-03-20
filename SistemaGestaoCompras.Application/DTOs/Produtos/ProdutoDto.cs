namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public Guid IdCategoria { get; set; }
        public Guid? IdMarca { get; set; }
        public string UnidadeBase { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public decimal? QuantidadeBase { get; set; }
    }
}