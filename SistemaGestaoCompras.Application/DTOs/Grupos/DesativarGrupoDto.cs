namespace SistemaGestaoCompras.Application.DTOs.Grupos
{
    public class DesativarGrupoDto
    {
        public Guid IdGrupo { get; set; }
        public Guid IdUsuarioSolicitante { get; set; }
    }
}