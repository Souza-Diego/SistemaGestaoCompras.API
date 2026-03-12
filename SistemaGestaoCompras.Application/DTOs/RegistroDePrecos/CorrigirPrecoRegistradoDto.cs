namespace SistemaGestaoCompras.Application.DTOs.RegistroDePrecos
{
    public class CorrigirPrecoRegistradoDto
    {
        public Guid IdRegistro { get; set; }
        public decimal NovoPreco { get; set; }
    }
}