namespace SistemaGestaoCompras.Domain.Entities
{
    public abstract class Entidade
    {
        public Guid Id { get; protected set; }
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
