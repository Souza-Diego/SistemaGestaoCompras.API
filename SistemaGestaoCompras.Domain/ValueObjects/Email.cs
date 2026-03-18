using SistemaGestaoCompras.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace SistemaGestaoCompras.Domain.ValueObjects
{
    public class Email
    {
        public string Endereco { get; }
        protected Email()
        {
            // Construtor protegido para ser usado pelo Entity Framework
            Endereco = null!;
        }
        
        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new AppValidationException("Não esqueça do email! Prometemos que não vamos enviar spam, mas precisamos de um endereço.");

            endereco = endereco.Trim().ToLower();

            if (!EmailValido(endereco))
            {
                throw new AppValidationException("Hum, esse formato de email parece meio estranho. Pode conferir se não faltou um @ ou um ponto?");
            }

            Endereco = endereco;
        }

        private static readonly Regex EmailRegex =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private bool EmailValido(string email)
        {
            return EmailRegex.IsMatch(email);
        }

        public override string ToString()
        {
            return Endereco;
        }
    }
}
