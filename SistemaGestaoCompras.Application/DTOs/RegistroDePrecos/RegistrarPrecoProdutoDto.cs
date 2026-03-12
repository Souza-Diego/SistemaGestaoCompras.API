namespace SistemaGestaoCompras.Application.DTOs.RegistroDePrecos
{
    public class RegistrarPrecoProdutoDto
    {
        public Guid IdProduto { get; set; }
        public Guid IdMercado { get; set; }
        public Guid IdUsuario { get; set; }
        public decimal Preco { get; set; }
        public decimal QuantidadeReferencia { get; set; }
        public string UnidadeReferencia { get; set; } = string.Empty;
    }
}
