using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class ListaDeComprasPadrao : Entidade
    {        
        public Guid IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        private readonly List<ItemListaPadrao> _itens;
        public IReadOnlyCollection<ItemListaPadrao> Itens => _itens.AsReadOnly();

        protected ListaDeComprasPadrao()
        {
            // Construtor protegido para uso do Entity Framework
            Nome = null!;
            _itens = new List<ItemListaPadrao>();
        }

        public ListaDeComprasPadrao(Guid idUsuario, string nome)
        {            
            IdUsuario = idUsuario;

            ValidarNome(nome);
            Nome = nome.Trim();
            Ativo = true;
            _itens = new List<ItemListaPadrao>();
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length < 2)
                throw new ArgumentException("O nome da lista de compras padrão deve conter pelo menos 2 caracteres.");
        }

        public void AlterarNome(string novoNome)
        {
            ValidarNome(novoNome);
            Nome = novoNome.Trim();
        }

        public void AdicionarItem(Guid idProduto, decimal quantidadePlanejada, UnidadeMedida unidade)
        {
            var item = new ItemListaPadrao(Id, idProduto, quantidadePlanejada, unidade);
            _itens.Add(item);
        }

        public void RemoverItem(Guid idProduto)
        {
            var item = _itens.FirstOrDefault(i => i.IdProduto == idProduto);
            if (item != null)
            {
                _itens.Remove(item);
            }
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}
