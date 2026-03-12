using BCrypt.Net;
using System.ComponentModel.DataAnnotations;

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
                throw new ValidationException("Uma porta sem chave não tranca. Digite uma senha para proteger sua conta!");

            if (!SenhaForte(senhaTexto))
                throw new ValidationException("Sua senha precisa de um pouco mais de 'músculo'. Tente misturar letras maiúsculas e minúsculas, números e símbolos para deixá-la imbatível.");

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