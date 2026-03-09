
namespace SistemaGestaoCompras.Application.DTOs.Marcas
{
    public class MarcaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public bool Ativo { get; set; }
    }
}
