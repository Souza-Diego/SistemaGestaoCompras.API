
namespace SistemaGestaoCompras.Application.DTOs.Convites
{
    public class EntrarGrupoPorCodigoDto
    {
        public string Codigo { get; set; } = null!;
        public Guid IdUsuario { get; set; }
    }
}
