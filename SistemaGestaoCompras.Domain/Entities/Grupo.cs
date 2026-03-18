using SistemaGestaoCompras.Domain.Enums;
namespace SistemaGestaoCompras.Domain.Entities
{
    public class Grupo : EntidadeAtiva
    {        
        public string Nome { get; private set; }
        public Guid IdCriadoPorUsuario { get; private set; }
        public DateTime DataCriacao { get; private set; }        

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
            GarantirAtivo();
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
            GarantirAtivo();
            var membro = _membros.FirstOrDefault(m => m.IdUsuario == idUsuario);

            if (membro == null)
                throw new InvalidOperationException("Usuário não encontrado no grupo.");

            if (membro.Papel == PapelGrupo.Administrador)
            {
                var totalAdministradores = _membros.Count(m => m.Papel == PapelGrupo.Administrador);

                if (totalAdministradores <= 1)
                    throw new InvalidOperationException("O grupo precisa ter pelo menos um administrador.");
            }

            _membros.Remove(membro);
        }

        public void TornarAdministrador(Guid idUsuario)
        {
            GarantirAtivo();
            var membro = _membros.FirstOrDefault(m => m.IdUsuario == idUsuario);

            if (membro == null)
                throw new InvalidOperationException("Usuário não pertence ao grupo.");

            if (membro.Papel == PapelGrupo.Administrador)
                throw new InvalidOperationException("Usuário já é administrador.");

            membro.TornarAdministrador();
        }

        public void RemoverAdministrador(Guid idUsuario)
        {
            GarantirAtivo();
            var membro = _membros.FirstOrDefault(m => m.IdUsuario == idUsuario);

            if (membro == null)
                throw new InvalidOperationException("Usuário não pertence ao grupo.");

            if (idUsuario == IdCriadoPorUsuario)
                throw new InvalidOperationException("O criador do grupo não pode perder o papel de administrador.");

            if (membro.Papel != PapelGrupo.Administrador)
                throw new InvalidOperationException("Usuário não é administrador.");

            var totalAdministradores = _membros.Count(m => m.Papel == PapelGrupo.Administrador);

            if (totalAdministradores <= 1)
                throw new InvalidOperationException("O grupo precisa ter pelo menos um administrador.");

            membro.TornarMembro();
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
    }
}
