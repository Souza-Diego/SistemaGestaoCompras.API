
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class ItemLista : EntidadeAtiva
    {        
        public Guid IdListaDeCompras { get; private set; }
        public Guid IdProduto { get; private set; }
        public decimal QuantidadePlanejada { get; private set; }
        public UnidadeMedida Unidade { get; private set; }        

        protected ItemLista()
        {
            // Construtor protegido para uso do Entity Framework
            Unidade = null!;
        }

        public ItemLista(
            Guid idListaDeCompras, 
            Guid idProduto, 
            decimal quantidadePlanejada, 
            UnidadeMedida unidade)
        {
            if(idListaDeCompras == Guid.Empty)
                throw new ArgumentException("Lista de compras inválida.");

            if(idProduto == Guid.Empty)
                throw new ArgumentException("Produto inválido.");

            ValidarQuantidadePlanejada(quantidadePlanejada);

            if (unidade == null)
                throw new ArgumentNullException(nameof(unidade), "Unidade de medida é obrigatória.");
                        
            IdListaDeCompras = idListaDeCompras;
            IdProduto = idProduto;
            QuantidadePlanejada = quantidadePlanejada;
            Unidade = unidade;            
        }

        private void ValidarQuantidadePlanejada(decimal quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade planejada deve ser maior que zero.");
        }

        public void AlterarQuantidadePlanejada(decimal novaQuantidade)
        {
            ValidarQuantidadePlanejada(novaQuantidade);
            QuantidadePlanejada = novaQuantidade;
        }

        public void AlterarUnidade(UnidadeMedida novaUnidade)
        {
            if (novaUnidade == null)
                throw new ArgumentNullException(nameof(novaUnidade), "Unidade de medida é obrigatória.");
    
            Unidade = novaUnidade;
        }        
    }
}
