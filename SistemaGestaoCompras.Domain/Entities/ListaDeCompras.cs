using SistemaGestaoCompras.Domain.Enums;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class ListaDeCompras
    {
        public Guid IdListaDeCompras { get; private set; }
        public string Nome { get; private set; }
        public Guid IdUsuario { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public StatusLista Status { get; private set; }

        private readonly List<ItemLista> _itens;
        public IReadOnlyCollection<ItemLista> Itens => _itens.AsReadOnly();

        protected ListaDeCompras()
        {
            // Construtor protegido para uso do Entity Framework
            Nome = null!;
            _itens = new List<ItemLista>();
        }

        public ListaDeCompras(string nome, Guid idUsuario)
        {
            if(idUsuario == Guid.Empty)
                throw new ArgumentException("Usuário inválido.");

            IdListaDeCompras = Guid.NewGuid();
            ValidarNome(nome);
            Nome = nome.Trim();
            IdUsuario = idUsuario;
            DataCriacao = DateTime.UtcNow;
            Status = StatusLista.Aberta;
            _itens = new List<ItemLista>();
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length < 2)
                throw new ArgumentException("O nome da lista de compras deve conter pelo menos 2 caracteres.");
        }

        public void AlterarNome(string novoNome)
        {
            ValidarNome(novoNome);
            Nome = novoNome.Trim();
        }

        public void AdicionarItem(ItemLista item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "O item não pode ser nulo.");
            _itens.Add(item);
        }

        public void RemoverItem(Guid idItem)
        {
            var item = _itens.FirstOrDefault(i => i.IdProduto == idItem);
            if (item != null)
            {
                _itens.Remove(item);
            }
        }

        public void Finalizar()
        {
            if (Status == StatusLista.Finalizada)
                throw new InvalidOperationException("A lista de compras já está finalizada.");
            Status = StatusLista.Finalizada;
        }

        public void Reabrir()
            {
                if (Status == StatusLista.Aberta)
                    throw new InvalidOperationException("A lista de compras já está aberta.");
                Status = StatusLista.Aberta;
        }
    }
}
