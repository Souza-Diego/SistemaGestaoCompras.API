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
                throw new ArgumentException("O email não pode ser vazio.");

            endereco = endereco.Trim().ToLower();

            if (!EmailValido(endereco))
            {
                throw new ArgumentException("Email inválido.");
            }

            Endereco = endereco;
        }

        private bool EmailValido(string email)
        {
            // Expressão regular simples para validar o formato do email
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        public override string ToString()
        {
            return Endereco;
        }

    }
}
