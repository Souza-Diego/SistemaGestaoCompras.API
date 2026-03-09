namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class AtualizarProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public Guid IdCategoria { get; set; }
        public Guid? IdMarca { get; set; }        
    }
}
