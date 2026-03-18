namespace SistemaGestaoCompras.Domain.Entities
{
    public class Mercado : EntidadeAtiva
    {        
        public string Nome { get; private set; }       
        
        protected Mercado()
        {
            // Construtor protegido para uso do Entity Framework
            Nome = null!;            
        }

        public Mercado(string nome)
        {            
            ValidarNome(nome);
            Nome = nome.Trim();            
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
            GarantirAtivo();
            ValidarNome(novoNome);
            Nome = novoNome.Trim();
        }        
    }
}
