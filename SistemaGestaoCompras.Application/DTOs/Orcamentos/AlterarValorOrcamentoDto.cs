namespace SistemaGestaoCompras.Application.DTOs.Orcamentos
{
    public class AlterarValorOrcamentoDTO
    {
        public Guid IdOrcamento { get; set; }
        public decimal NovoValor { get; set; }
    }
}