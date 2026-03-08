
namespace SistemaGestaoCompras.Application.DTOs.Grupos
{
    public class RemoverMembroGrupoDto
    {
        public Guid IdGrupo { get; set; }
        public Guid IdUsuarioSolicitante { get; set; }
        public Guid IdUsuarioRemover { get; set; }
    }
}
