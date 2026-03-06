using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class Compra : Entidade
    {
        public Guid IdUsuario { get; private set; }
        public Guid IdMercado { get; private set; }
        public DateTime DataCompra { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataFinalizacao { get; private set; }
        public bool Finalizada { get; private set; }
        public bool AtivaParaRelatorio { get; private set; }
        public Dinheiro ValorTotal { get; private set; }
        private readonly List<ItemCompra> _itens = new();
        public IReadOnlyCollection<ItemCompra> Itens => _itens.AsReadOnly();

        protected Compra() 
        {
            // Construtor protegido para uso do Entity Framework
             ValorTotal = null!;
        }

        public Compra(Guid idUsuario, Guid idMercado, DateTime dataCompra)
        {            
            IdUsuario = idUsuario;
            IdMercado = idMercado;
            DataCriacao = DateTime.UtcNow;
            DataCompra = dataCompra;
            Finalizada = false;
            AtivaParaRelatorio = true;
            ValorTotal = Dinheiro.Zero;
        }

        public void AdicionarItem(
            Guid idProduto,
            string nomeProduto,
            decimal quantidade,
            Dinheiro precoUnitario,
            UnidadeMedida unidade)
        {
            if (Finalizada)
                throw new InvalidOperationException("compra finalizada.");

            var itemExistente = _itens.FirstOrDefault(i => i.IdProduto == idProduto);

            if (itemExistente != null)
            {
                itemExistente.AdicionarQuantidade(quantidade);
                return;
            }

            var item = new ItemCompra(Id, idProduto, nomeProduto, quantidade, precoUnitario, unidade);
            _itens.Add(item);
        }
        public void RemoverItem(Guid idItemCompra)
        {
            if (Finalizada)
                throw new InvalidOperationException("compra finalizada.");

            var item = _itens.FirstOrDefault(i => i.Id == idItemCompra);

            if (item != null)
                _itens.Remove(item);
        }

        public void RemoverDosRelatorios()
        {
            AtivaParaRelatorio = false;
        }

        public void Finalizar()
        {
            if (!_itens.Any())
                throw new InvalidOperationException("compra deve conter pelo menos um item.");

            ValorTotal = CalcularValorTotal();

            Finalizada = true;
            DataFinalizacao = DateTime.UtcNow;
        }

        public Dinheiro CalcularValorTotal()
        {
            return _itens
                .Select(i => i.CalcularSubTotal())
                .Aggregate(Dinheiro.Zero, (total, atual) => total + atual);
        }
    }
}
