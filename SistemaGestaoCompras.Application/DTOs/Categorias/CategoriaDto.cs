
namespace SistemaGestaoCompras.Application.DTOs.Categorias
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public bool Ativo { get; set; }
    }
}
