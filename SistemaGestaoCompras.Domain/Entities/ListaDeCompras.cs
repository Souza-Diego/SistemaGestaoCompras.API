using SistemaGestaoCompras.Domain.Enums;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class ListaDeCompras : Entidade
    {        
        public string Nome { get; private set; }
        public Guid? IdUsuario { get; private set; }
        public Guid? IdGrupo { get; private set; }
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
                        
            ValidarNome(nome);
            Nome = nome.Trim();
            IdUsuario = idUsuario;
            DataCriacao = DateTime.UtcNow;
            Status = StatusLista.Aberta;
            _itens = new List<ItemLista>();
            ValidarProprietario();
        }

        public ListaDeCompras(string nome, Guid idGrupo, bool isListaGrupo)
        {
            if(idGrupo == Guid.Empty)
                throw new ArgumentException("Grupo inválido.");            
            ValidarNome(nome);
            Nome = nome.Trim();
            IdGrupo = idGrupo;
            DataCriacao = DateTime.UtcNow;
            Status = StatusLista.Aberta;
            _itens = new List<ItemLista>();
            ValidarProprietario();
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
            var item = _itens.FirstOrDefault(i => i.Id == idItem);
            if (item != null)
            {
                _itens.Remove(item);
            }
        }

        public void ValidarProprietario()
        {
            if (IdUsuario == null && IdGrupo == null)
            {
                throw new InvalidOperationException("A lista precisa pertencer a um usuário ou a um grupo.");
            }

            if (IdUsuario != null && IdGrupo != null)
            {
                throw new InvalidOperationException("A lista não pode pertencer a um usuário e a um grupo ao mesmo tempo.");
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
