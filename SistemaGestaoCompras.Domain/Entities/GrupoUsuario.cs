using SistemaGestaoCompras.Domain.Enums;
namespace SistemaGestaoCompras.Domain.Entities
{
    public class GrupoUsuario : Entidade
    {        
        public Guid IdGrupo { get; private set; }
        public Guid IdUsuario { get; private set; }
        public PapelGrupo Papel { get; private set; }
        public DateTime DataEntrada { get; private set; }
        protected GrupoUsuario()
        {
            // Construtor protegido para uso do Entity Framework
        }

        public GrupoUsuario(Guid idGrupo, Guid idUsuario, PapelGrupo papel)
        {            
            IdGrupo = idGrupo;
            IdUsuario = idUsuario;
            Papel = papel;
            DataEntrada = DateTime.UtcNow;
        }

        public void TornarAdministrador()
        {
            Papel = PapelGrupo.Administrador;
        }

        public void TornarMembro()
        {
            Papel = PapelGrupo.Membro;
        }
    }
}
