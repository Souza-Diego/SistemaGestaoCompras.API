namespace SistemaGestaoCompras.Application.DTOs.Grupos
{
    public class AdicionarMembroGrupoDto
    {
        public Guid GrupoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid UsuarioConvidadoId { get; set; }
    }
}