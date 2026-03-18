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

        protected string NomeEntidade => GetType().Name;

        protected void GarantirAtivo()
        {
            if (!Ativo)
                throw new AppDomainException($"Não podemos fazer isso. Esse(a) {NomeEntidade} não está mais ativo(a) no sistema.");
        }

        protected void GarantirInativo()
        {
            if (Ativo)
                throw new AppDomainException($"Esse(a) {NomeEntidade} já está ativo(a) no sistema.");
        }

        public void Ativar()
        {
            GarantirInativo();
            Ativo = true;
        }
        public void Desativar()
        {
            GarantirAtivo();
            Ativo = false;
        }
    }
}
