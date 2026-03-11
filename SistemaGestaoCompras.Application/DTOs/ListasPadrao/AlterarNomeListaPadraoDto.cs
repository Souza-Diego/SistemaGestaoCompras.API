namespace SistemaGestaoCompras.Application.DTOs.ListasPadrao
{
    public class AlterarNomeListaPadraoDto
    {
        public Guid Id { get; set; }
        public string NovoNome { get; set; } = string.Empty;
    }
}