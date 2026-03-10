namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public Guid IdCategoria { get; set; }
        public Guid? IdMarca { get; set; }
        public string UnidadeBase { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public bool Ativo { get; set; }
    }
}