using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Domain.Entities
{
    public abstract class EntidadeAtiva : Entidade
    {
        public bool Ativo {  get; private set; }

        protected EntidadeAtiva()
        {
            Ativo = true;
        }

        protected void GarantirAtivo()
        {
            if (!Ativo)
                throw new DomainException($"Não podemos fazer isso. {GetType().Name} não está mais ativo no sistema.");
        }

        public void Ativar()
        {
            Ativo = true;
        }
        public void Desativar()
        {
            Ativo = false;
        }
    }
}
