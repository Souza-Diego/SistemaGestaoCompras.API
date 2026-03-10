namespace SistemaGestaoCompras.Application.DTOs.Usuarios
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Plano { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}