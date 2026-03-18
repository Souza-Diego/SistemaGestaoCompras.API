namespace SistemaGestaoCompras.Domain.Exceptions
{
    public class AppDomainException : Exception
    {
        public AppDomainException(string mensagem) : base(mensagem)
        {
        }
    }
}
