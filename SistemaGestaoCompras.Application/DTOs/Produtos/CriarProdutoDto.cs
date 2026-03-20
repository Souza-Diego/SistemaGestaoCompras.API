namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class CriarProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public Guid IdCategoria { get; set; }
        public Guid? IdMarca { get; set; }
        public string UnidadeBase { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; }
        public decimal? QuantidadeBase { get; set; }
    }
}