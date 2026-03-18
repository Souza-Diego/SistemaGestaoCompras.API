namespace SistemaGestaoCompras.Domain.Exceptions
{
    public class AppNotFoundException : Exception
    {
        public AppNotFoundException(string entidade, object id)
            : base($"{entidade} com identificador {id} não foi encontrado.")
        {
        }

        public AppNotFoundException(string mensagem) : base(mensagem)
        {
        }
    }
}