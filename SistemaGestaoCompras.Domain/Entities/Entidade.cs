namespace SistemaGestaoCompras.Domain.Entities
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        protected Entidade(Guid id)
        {
            Id = id;
        }
    }
}
