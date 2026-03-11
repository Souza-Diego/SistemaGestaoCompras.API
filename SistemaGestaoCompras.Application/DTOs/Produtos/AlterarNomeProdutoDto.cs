namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class AlterarNomeProdutoDto
    {
        public Guid Id { get; set; }
        public string NovoNome { get; set; } = null!;
    }
}