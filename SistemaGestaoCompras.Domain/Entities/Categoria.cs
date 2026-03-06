
namespace SistemaGestaoCompras.Domain.Entities
{
    public class Categoria
    {
        public Guid IdCategoria { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        protected Categoria()
        {
            // Construtor protegido para uso do Entity Framework
            Nome = null!;
        }

        public Categoria(string nome)
        {
            IdCategoria = Guid.NewGuid();
            ValidarNome(nome);
            Nome = nome.Trim();
            Ativo = true;
        }

        public void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) ||
                nome.Trim().Length < 2 ||
                nome.Any(char.IsDigit) ||
                nome.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
            {
                throw new ArgumentException("Nome inválido. O nome deve conter pelo menos 2 caracteres e não pode conter números ou caracteres especiais.");
            }
        }

        public void AlterarNome(string novoNome)
        {
            ValidarNome(novoNome);
            Nome = novoNome.Trim();
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
