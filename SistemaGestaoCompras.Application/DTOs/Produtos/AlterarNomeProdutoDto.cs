namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class AlterarNomeProdutoDto
    {
        public Guid Id { get; set; }
        public string NovoNome { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; }
    }
}