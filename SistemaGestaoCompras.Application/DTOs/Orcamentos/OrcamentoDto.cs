namespace SistemaGestaoCompras.Application.DTOs.Orcamentos
{
    public class OrcamentoDto
    {
        public Guid Id { get; set; }        
        public int Ano { get; set; }
        public int Mes { get; set; }
        public decimal ValorPlanejado { get; set; }
    }
}
