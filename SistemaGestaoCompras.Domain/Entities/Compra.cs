using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class Compra
    {
        public Guid IdCompra { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdMercado { get; private set; }
        public DateTime DataCompra { get; private set; }
        public bool Finalizada { get; private set; }
        private readonly List<ItemCompra> _itens = new();
        public IReadOnlyCollection<ItemCompra> Itens => _itens.AsReadOnly();

        protected Compra() { }

        public Compra(Guid idUsuario, Guid idMercado)
        {
            IdCompra = Guid.NewGuid();
            IdUsuario = idUsuario;
            IdMercado = idMercado;
            DataCompra = DateTime.UtcNow;
            Finalizada = false;
        }

        public void AdicionarItem(
            Guid idProduto,
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

            var item = new ItemCompra(IdCompra, idProduto, quantidade, precoUnitario, unidade);
            _itens.Add(item);
        }

        public void RemoverItem(Guid idItemCompra)
        {
            if (Finalizada)
                throw new InvalidOperationException("compra finalizada.");

            var item = _itens.FirstOrDefault(i => i.IdItemCompra == idItemCompra);

            if (item != null)
                _itens.Remove(item);
        }

        public void Finalizar()
        {
            if (!_itens.Any())
                throw new InvalidOperationException("compra deve conter pelo menos um item.");

            Finalizada = true;
        }

        public Dinheiro CalcularValorTotal()
        {
            return _itens
                .Select(i => i.CalcularSubTotal())
                .Aggregate(Dinheiro.Zero, (total, atual) => total + atual);
        }
    }
}
