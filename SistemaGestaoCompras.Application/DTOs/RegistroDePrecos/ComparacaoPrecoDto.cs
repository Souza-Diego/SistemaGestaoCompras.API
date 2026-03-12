namespace SistemaGestaoCompras.Application.DTOs.RegistroDePrecos
{
    public class ComparacaoPrecoDto
    {
        public Guid MercadoId { get; set; }
        public decimal Preco { get; set; }
        public decimal QuantidadeReferencia { get; set; }
        public string UnidadeReferencia { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; }
    }
}