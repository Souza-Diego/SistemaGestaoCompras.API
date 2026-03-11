namespace SistemaGestaoCompras.Application.DTOs.Mercados
{
    public class AlterarNomeMercadoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
    }
}
