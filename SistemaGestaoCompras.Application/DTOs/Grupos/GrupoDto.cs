namespace SistemaGestaoCompras.Application.DTOs.Grupos
{
    public class GrupoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public Guid CriadoPor { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}