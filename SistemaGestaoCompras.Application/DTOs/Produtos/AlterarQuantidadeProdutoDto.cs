namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class AlterarQuantidadeProdutoDto
    {
        public Guid Id { get; set; }
        public decimal? NovaQuantidade { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
