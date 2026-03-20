namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class AlterarUnidadeProdutoDto
    {
        public Guid Id { get; set; }
        public string NovaUnidade { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; }
    }
}