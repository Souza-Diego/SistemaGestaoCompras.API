namespace SistemaGestaoCompras.Application.DTOs.Orcamentos
{
    public class CriarOrcamentoMensalDTO
    {
        public Guid IdUsuario { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public decimal ValorPlanejado { get; set; }
    }
}