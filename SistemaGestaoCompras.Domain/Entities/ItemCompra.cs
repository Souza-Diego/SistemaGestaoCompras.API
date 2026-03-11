using SistemaGestaoCompras.Domain.ValueObjects;
namespace SistemaGestaoCompras.Domain.Entities
{
    public class ItemCompra : Entidade
    {        
        public Guid IdCompra { get; private set; }
        public Guid IdProduto { get; private set; }
        public string NomeProdutoSnapshot { get; private set; }
        public decimal Quantidade { get; private set; }
        public Dinheiro PrecoUnitario { get; private set; }
        public UnidadeMedida Unidade { get; private set; }

        protected ItemCompra()
        {
            // Construtor protegido para uso do Entity Framework
            Unidade = null!;
            PrecoUnitario = null!;
            NomeProdutoSnapshot = null!;
        } 

        public ItemCompra(
            Guid idCompra,
            Guid idProduto,
            string nomeProduto,
            decimal quantidade,
            Dinheiro precoUnitario,
            UnidadeMedida unidade)
        {            
            IdCompra = idCompra;
            IdProduto = idProduto;
            NomeProdutoSnapshot = nomeProduto;
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

        public void AlterarQuantidade(decimal quantidade)
        {
            ValidarQuantidade(quantidade);
            Quantidade = quantidade;
        }

        public void AlterarPreco(Dinheiro preco)
        {
            PrecoUnitario = preco;
        }
    }
}
