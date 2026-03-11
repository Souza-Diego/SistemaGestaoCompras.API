namespace SistemaGestaoCompras.Domain.Entities
{
    public class ConviteGrupo : Entidade
    {        
        public Guid IdGrupo { get; private set; }
        public string Codigo { get; private set; }
        public Guid IdCriadoPorUsuario { get; private set; }        
        public DateTime DataCriacao { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public bool Ativo { get; private set; }

        protected ConviteGrupo()
        {
            Codigo = null!;
        } 

        public ConviteGrupo(Guid idGrupo, Guid idCriadoPorUsuario, int diasValidade)
        {            
            IdGrupo = idGrupo;
            IdCriadoPorUsuario = idCriadoPorUsuario;
            Codigo = GerarCodigoConvite();
            DataCriacao = DateTime.UtcNow;
            DataExpiracao = DataCriacao.AddDays(diasValidade);
            Ativo = true;
        }

        public bool EstaExpirado()
        {
            return DateTime.UtcNow > DataExpiracao;
        }

        public bool EstaValido()
        {
            return Ativo && !EstaExpirado();
        }

        public void Desativar()
        {
            Ativo = false;
        }        

        private string GerarCodigoConvite()
        {
            return Guid.NewGuid().ToString("N")[..8].ToUpper();
        }
    }
}
