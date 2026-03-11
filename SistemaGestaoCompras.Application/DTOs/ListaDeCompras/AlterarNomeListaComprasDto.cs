namespace SistemaGestaoCompras.Application.DTOs.ListaDeCompras
{
    public class AlterarNomeListaComprasDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
