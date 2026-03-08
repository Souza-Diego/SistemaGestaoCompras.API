namespace SistemaGestaoCompras.Application.DTOs.Convites
{
    public class CriarConviteGrupoDto
    {
        public Guid IdGrupo { get; set; }
        public Guid IdUsuarioCriador { get; set; }
        public int DiasValidade { get; set; }
    }
}
