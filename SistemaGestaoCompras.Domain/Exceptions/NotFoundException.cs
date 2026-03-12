namespace SistemaGestaoCompras.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entidade, object id)
            : base($"{entidade} com identificador {id} não foi encontrado.")
        {
        }

        public NotFoundException(string mensagem) : base(mensagem)
        {
        }
    }
}