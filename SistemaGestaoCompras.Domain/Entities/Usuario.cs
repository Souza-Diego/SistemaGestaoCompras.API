using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Domain.Entities
{
    // Classe publica para ser usada em outras camadas do sistema
    public class Usuario : Entidade
    {   // Propriedades com métodos de acesso privados para garantir encapsulamento
        // GUID (Globally Unique Identifier) é um identificador único globalmente, garantindo que cada usuário tenha um ID exclusivo, mesmo em sistemas distribuídos
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public PlanoUsuario Plano { get; private set; }
        // Data de Criação para rastrear quando o usuário foi criado, útil para auditoria e gerenciamento de contas
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }

        // Construtor protegido para ser usado pelo Entity Framework
        protected Usuario() 
        {
            // Inicializa as propriedades para evitar erros de null reference
            Nome = null!;
            Email = null!;
            Senha = null!;
        }

        public Usuario(string nome, Email email, Senha senha, TipoUsuario tipoUsuario)
        {
            ValidarNome(nome);
                        
            Nome = nome.Trim();
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Plano = PlanoUsuario.Gratuito; // Todos os usuários começam com o plano gratuito
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) ||
                nome.Trim().Length < 2 ||
                nome.Any(char.IsDigit) ||
                nome.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
            {
                throw new ValidationException("Quase lá! Mas precisamos de um nome real, com pelo menos 2 letras e sem 'temperos' (números ou símbolos).");
            }                
        }        

        public void AlterarNome(string novoNome)
        {                     
            ValidarNome(novoNome);
            Nome = novoNome;
        }

        public void AlterarEmail(Email novoEmail)
        {
            Email = novoEmail;
        }

        public void AlterarSenha(Senha novaSenha)
        {
            Senha = novaSenha;
        }

        public void DesativarConta()
        {
            Ativo = false;
        }

        public void ReativarConta()
        {
            Ativo = true;
        }

        public bool IsADM()
        {
            return TipoUsuario == TipoUsuario.Administrador;
        }

        public void AlterarPlano(PlanoUsuario novoPlano)
        {
            if (Plano == novoPlano)
                throw new DomainException("Esse plano já está ativo na sua conta.");

            Plano = novoPlano;
        }

        public bool IsPremium()
        {
            return Plano == PlanoUsuario.Premium;
        }
    }
}
