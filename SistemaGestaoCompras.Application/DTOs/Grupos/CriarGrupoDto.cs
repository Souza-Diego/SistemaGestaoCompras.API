namespace SistemaGestaoCompras.Application.DTOs.Grupos
{
    public class CriarGrupoDto
    {
        public string Nome { get; set; } = null!;
        public Guid IdUsuarioCriador { get; set; }
    }
}
