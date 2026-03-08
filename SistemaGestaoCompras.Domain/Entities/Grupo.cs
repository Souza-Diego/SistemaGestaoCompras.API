using SistemaGestaoCompras.Domain.Enums;
namespace SistemaGestaoCompras.Domain.Entities
{
    public class Grupo : Entidade
    {        
        public string Nome { get; private set; }
        public Guid IdCriadoPorUsuario { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; set; }

        private readonly List<GrupoUsuario> _membros = new();
        public IReadOnlyCollection<GrupoUsuario> Membros => _membros.AsReadOnly();

        protected Grupo()
        {
            // Construtor protegido para uso do Entity Framework
            Nome = null!;
        }

        public Grupo(string nome, Guid idCriadoPorUsuario)
        {            
            ValidarNome(nome);
            Nome = nome;
            IdCriadoPorUsuario = idCriadoPorUsuario;
            DataCriacao = DateTime.UtcNow;
            Ativo = true;

            var criador = new GrupoUsuario(Id, idCriadoPorUsuario, PapelGrupo.Administrador);
            _membros.Add(criador);
        }

        public void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome do grupo é obrigatório.");
            }
        }

        public void AlterarNome(string novoNome)
        {
            ValidarNome(novoNome);
            Nome = novoNome;
        }

        public void AdicionarMembro(Guid idUsuario)
        {
            if (!Ativo)
            {
                throw new InvalidOperationException("Não é possível adicionar membros a um grupo desativado.");
            }
            if (_membros.Any(m => m.IdUsuario == idUsuario))
            {
                throw new InvalidOperationException("Usuário já faz parte do grupo");
            }

            var membro = new GrupoUsuario(Id, idUsuario, PapelGrupo.Membro);
            _membros.Add(membro);
        }

        public void RemoverMembro(Guid idUsuario)
        {
            if(idUsuario == IdCriadoPorUsuario)
            {
                throw new InvalidOperationException("O criador do grupo não pode ser removido.");
            }
                        
            var membro = _membros.FirstOrDefault(m => m.IdUsuario == idUsuario);

            if (membro == null)
            {
                throw new InvalidOperationException("Usuário não encontrado no grupo.");
            }
            _membros.Remove(membro);
        }

        public bool UsuarioPertenceAoGrupo(Guid idUsuario)
        {
            return _membros.Any(m => m.IdUsuario == idUsuario);
        }

        public bool UsuarioIsAdministrador(Guid idUsuario)
        {
            return _membros.Any(m =>
            m.IdUsuario == idUsuario &&
            m.Papel == PapelGrupo.Administrador);
        }

        public void Desativar()
        {
            Ativo = false;
        }

    }
}
