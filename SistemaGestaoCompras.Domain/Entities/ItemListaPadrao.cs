using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class ItemListaPadrao
    {
        public Guid IdItemListaPadrao { get; private set; }
        public Guid IdListaDeComprasPadrao { get; private set; }
        public Guid IdProduto { get; private set; }
        public decimal QuantidadePlanejada { get; private set; }
        public UnidadeMedida Unidade { get; private set; }
        
        protected ItemListaPadrao()
        {
            // Construtor protegido para uso do Entity Framework
            Unidade = null!;
        }

        public ItemListaPadrao(
            Guid idListaDeComprasPadrao,
            Guid idProduto,
            decimal quantidadePlanejada,
            UnidadeMedida unidade)
        {
            IdItemListaPadrao = Guid.NewGuid();
            IdListaDeComprasPadrao = idListaDeComprasPadrao;
            IdProduto = idProduto;

            ValidarQuantidade(quantidadePlanejada);
            QuantidadePlanejada = quantidadePlanejada;
            Unidade = unidade;
        }

        private void ValidarQuantidade(decimal quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        public void AlterarQuantidadePlanejada(decimal novaQuantidade)
        {
            ValidarQuantidade(novaQuantidade);
            QuantidadePlanejada = novaQuantidade;
        }

        public void AlterarUnidade(UnidadeMedida novaUnidade)
        {
            if (novaUnidade == null)
                throw new ArgumentNullException(nameof(novaUnidade), "A unidade de medida é obrigatória.");
            Unidade = novaUnidade;
        }        

    }
}
