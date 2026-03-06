using SistemaGestaoCompras.Domain.ValueObjects;
namespace SistemaGestaoCompras.Domain.Entities
{
    public class ItemCompra
    {
        public Guid IdItemCompra { get; private set; }
        public Guid IdCompra { get; private set; }
        public Guid IdProduto { get; private set; }
        public decimal Quantidade { get; private set; }
        public Dinheiro PrecoUnitario { get; private set; }
        public UnidadeMedida Unidade { get; private set; }

        protected ItemCompra()
        {
            // Construtor protegido para uso do Entity Framework
            Unidade = null!;
            PrecoUnitario = null!;
        } 

        public ItemCompra(
            Guid idCompra,
            Guid idProduto,
            decimal quantidade,
            Dinheiro precoUnitario,
            UnidadeMedida unidade)
        {
            IdItemCompra = Guid.NewGuid();
            IdCompra = idCompra;
            IdProduto = idProduto;
            ValidarQuantidade(quantidade);
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Unidade = unidade;
        }

        private void ValidarQuantidade(decimal quantidade)
        {
            if(quantidade <= 0)
            {
                throw new ArgumentException("Quantidade deve ser maior que zero");
            }
        }        

        public void AdicionarQuantidade(decimal quantidade)
        {
            Quantidade += quantidade;
        }

        public Dinheiro CalcularSubTotal()
        {
            return PrecoUnitario * Quantidade;
        }
    }
}
