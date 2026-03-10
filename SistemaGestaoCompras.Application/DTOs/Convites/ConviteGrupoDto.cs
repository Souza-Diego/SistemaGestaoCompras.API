namespace SistemaGestaoCompras.Application.DTOs.Convites
{
    public class ConviteGrupoDto
    {
        public Guid Id { get; set; }
        public Guid GrupoId { get; set; }
        public string Codigo { get; set; } = null!;
        public Guid IdCriadoPorUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public bool Ativo { get; set; }
    }
}
