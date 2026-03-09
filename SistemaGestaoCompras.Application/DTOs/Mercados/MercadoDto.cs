namespace SistemaGestaoCompras.Application.DTOs.Mercados
{
    public class MercadoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public bool Ativo { get; set; }
    }
}
