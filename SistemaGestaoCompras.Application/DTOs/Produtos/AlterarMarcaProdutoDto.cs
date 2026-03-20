namespace SistemaGestaoCompras.Application.DTOs.Produtos
{
    public class AlterarMarcaProdutoDto
    {
        public Guid Id { get; set; }
        public Guid? NovaMarcaId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}