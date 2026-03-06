using System.Text;
using System.Security.Cryptography;

namespace SistemaGestaoCompras.Domain.ValueObjects
{
    public class Senha
    {
        public string Hash { get; }
        protected Senha() 
        {
            // Construtor protegido para ser usado pelo Entity Framework
            Hash = null!;
        }
        public Senha(string senhaTexto)
        {
            if(string.IsNullOrWhiteSpace(senhaTexto))
                throw new ArgumentException("A senha não pode ser vazia.");

            if (SenhaForte(senhaTexto))
            {
                throw new ArgumentException("A senha não atende aos requisitos mínimos");
            }

            Hash = GerarHash(senhaTexto);
        }

        private bool SenhaForte(string senha)
        {
            // Verifica se a senha tem pelo menos 8 caracteres, contém letras maiúsculas, minúsculas, números e caracteres especiais
            return senha.Length >= 8 &&
                senha.Any(char.IsUpper) &&
                senha.Any(char.IsLower) &&
                senha.Any(char.IsDigit) &&
                senha.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
