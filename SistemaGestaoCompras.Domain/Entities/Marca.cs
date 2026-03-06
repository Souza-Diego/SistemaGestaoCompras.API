
namespace SistemaGestaoCompras.Domain.Entities
{
    public class Marca
    {
        public Guid IdMarca { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        protected Marca()
        {
            // Construtor protegido para uso do Entity Framework
            Nome = null!;
        }

        public Marca(string nome)
        {
            IdMarca = Guid.NewGuid();
            ValidarNome(nome);
            Nome = nome.Trim();
            Ativo = true;
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da marca não pode ser vazio.");
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
    }
}
