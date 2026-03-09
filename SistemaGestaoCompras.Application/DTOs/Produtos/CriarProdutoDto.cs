using SistemaGestaoCompras.Domain.Enums;
namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class CriarProdutoDto
    {
        public string Nome { get; set; } = null!;
        public Guid IdCategoria { get; set; }
        public Guid? IdMarca { get; set; }
        public string UnidadeBase { get; set; } = null!;        
    }
}
