namespace SistemaGestaoCompras.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string mensagem) : base(mensagem)
        {
        }
    }
}