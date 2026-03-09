namespace SistemaGestaoCompras.Application.DTOs.Usuarios
{
    public class AlterarPerfilDto
    {
        public Guid Id { get; set; }
        public string NovoNome { get; set; } = null!;
        public string NovoEmail { get; set; } = null!;
    }
}
