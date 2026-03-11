using BCrypt.Net;

namespace SistemaGestaoCompras.Domain.ValueObjects
{
    public class Senha
    {
        public string Hash { get; }

        protected Senha()
        {
            // Construtor para o Entity Framework
            Hash = null!;
        }

        public Senha(string senhaTexto)
        {
            if (string.IsNullOrWhiteSpace(senhaTexto))
                throw new ArgumentException("A senha não pode ser vazia.");

            if (!SenhaForte(senhaTexto))
                throw new ArgumentException("A senha não atende aos requisitos mínimos.");

            Hash = BCrypt.Net.BCrypt.HashPassword(senhaTexto);
        }

        private bool SenhaForte(string senha)
        {
            // Verifica se a senha tem pelo menos 8 caracteres,
            // contém letras maiúsculas, minúsculas, números e caracteres especiais
            return senha.Length >= 8 &&
                   senha.Any(char.IsUpper) &&
                   senha.Any(char.IsLower) &&
                   senha.Any(char.IsDigit) &&
                   senha.Any(ch => !char.IsLetterOrDigit(ch));
        }

        public bool VerificarSenha(string senhaDigitada)
        {
            return BCrypt.Net.BCrypt.Verify(senhaDigitada, Hash);
        }
    }
}    