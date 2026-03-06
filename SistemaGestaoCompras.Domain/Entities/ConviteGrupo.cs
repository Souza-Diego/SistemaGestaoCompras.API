using SistemaGestaoCompras.Domain.Enums;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class ConviteGrupo : Entidade
    {        
        public Guid IdGrupo { get; private set; }
        public Guid IdUsuarioConvidado { get; private set; }
        public Guid IdUsuarioConvidante { get; private set; }
        public StatusConvite Status { get; private set; }
        public DateTime DataConvite { get; private set; }
        public DateTime? DataResposta { get; private set; }

        protected ConviteGrupo() { }

        public ConviteGrupo(Guid idGrupo, Guid idUsuarioConvidado, Guid idUsuarioConvidante)
        {            
            IdGrupo = idGrupo;
            IdUsuarioConvidado = idUsuarioConvidado;
            IdUsuarioConvidante = idUsuarioConvidante;
            Status = StatusConvite.Pendente;
            DataConvite = DateTime.UtcNow;
        }

        public void Aceitar()
        {
            if (Status != StatusConvite.Pendente)
                throw new InvalidOperationException("O convite já foi respondido.");
            Status = StatusConvite.Aceito;
            DataResposta = DateTime.UtcNow;
        }

        public void Recusar()
        {
            if (Status != StatusConvite.Pendente)
                throw new InvalidOperationException("O convite já foi respondido.");
            Status = StatusConvite.Recusado;
            DataResposta = DateTime.UtcNow;
        }
    }
}
