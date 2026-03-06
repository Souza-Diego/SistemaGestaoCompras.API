namespace SistemaGestaoCompras.Domain.Entities
{
    public class Mercado
    {
        public Guid IdMercado { get; private set; }
        public string Nome { get; private set; }
        
        public bool Ativo { get; private set; }

        protected Mercado()
        {
            // Construtor protegido para uso do Entity Framework
            Nome = null!;            
        }

        public Mercado(string nome)
        {
            IdMercado = Guid.NewGuid();
            ValidarNome(nome);
            Nome = nome.Trim();
            Ativo = true;
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome do mercado é ogrigatório");
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
    }
}
