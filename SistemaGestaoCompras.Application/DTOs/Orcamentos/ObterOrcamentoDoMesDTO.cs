namespace SistemaGestaoCompras.Application.DTOs.Orcamentos
{
    public class ObterOrcamentoDoMesDTO
    {
        public Guid IdUsuario { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}