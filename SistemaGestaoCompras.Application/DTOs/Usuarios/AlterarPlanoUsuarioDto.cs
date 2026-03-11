using SistemaGestaoCompras.Domain.Enums;

namespace SistemaGestaoCompras.Application.DTOs.Usuarios
{
    public class AlterarPlanoUsuarioDto
    {
        public Guid Id { get; set; }
        public PlanoUsuario NovoPlano { get; set; }
    }
}