namespace SistemaGestaoCompras.Domain.Exceptions
{
    public class AppValidationException : Exception
    {
        public AppValidationException(string mensagem) : base(mensagem)
        {
        }
    }
}