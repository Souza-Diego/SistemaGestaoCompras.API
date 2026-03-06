using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class RegistroDePreco : Entidade
    {        
        public Guid IdProduto { get; private set; }
        public Guid IdMercado { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Dinheiro Preco { get; private set; }
        public decimal QuantidadeReferencia { get; set; }
        public UnidadeMedida UnidadeReferencia { get; set; }
        public DateTime DataRegistro { get; private set; }

        protected RegistroDePreco()
        {
            // Construtor protegido para uso do Entity Framework
            UnidadeReferencia = null!;
            Preco = null!;
        }

        public RegistroDePreco(
            Guid idProduto,
            Guid idMercado,
            Guid idUsuario,
            Dinheiro preco,
            decimal quantidadeReferencia,
            UnidadeMedida unidadeReferencia)
        {            
            IdProduto = idProduto;
            IdMercado = idMercado;
            IdUsuario = idUsuario;
            Preco = preco;
            ValidarQuantidadeReferencia(quantidadeReferencia);
            QuantidadeReferencia = quantidadeReferencia;
            UnidadeReferencia = unidadeReferencia;
            DataRegistro = DateTime.UtcNow;
        }              

        private void ValidarQuantidadeReferencia(decimal quantidadeReferencia)
        {
            if (quantidadeReferencia <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        public void CorrigirPreco(Dinheiro novoPreco)
        {
            Preco = novoPreco;            
        }
    }
}
