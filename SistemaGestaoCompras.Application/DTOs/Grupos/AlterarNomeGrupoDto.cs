namespace SistemaGestaoCompras.Application.DTOs.Grupos
{
    public class AlterarNomeGrupoDto
    {
        public Guid GrupoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string NovoNome { get; set; } = string.Empty;
    }
}