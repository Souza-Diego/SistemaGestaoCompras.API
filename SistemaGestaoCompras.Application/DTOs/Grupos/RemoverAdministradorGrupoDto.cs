namespace SistemaGestaoCompras.Application.DTOs.Grupos
{
    public class RemoverAdministradorGrupoDto
    {
        public Guid IdGrupo { get; set; }
        public Guid IdUsuarioSolicitante { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
