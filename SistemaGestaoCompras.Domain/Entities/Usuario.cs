using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class Usuario : EntidadeAtiva
    {    
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public PlanoUsuario Plano { get; private set; }
        public DateTime DataCriacao { get; private set; }        
        public TipoUsuario TipoUsuario { get; private set; }

        
        protected Usuario() 
        {            
            Nome = null!;
            Email = null!;
            Senha = null!;
        }

        public Usuario(string nome, Email email, Senha senha, TipoUsuario tipoUsuario)
        {
            ValidarNome(nome);
            ValidarEmail(email);
            ValidarSenha(senha);
                                                           
            Nome = nome.Trim();
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            AtualizarPlanoComBaseNoTipo();
            DataCriacao = DateTime.UtcNow;            
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) ||
                nome.Trim().Length < 2 ||
                nome.Any(char.IsDigit) ||
                nome.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch) && ch != '-' && ch != '.'))
            {
                throw new AppValidationException("Quase lá! Mas precisamos de um nome real, com pelo menos 2 letras e sem 'temperos' (números ou símbolos).");
            }                
        }
        
        public void ValidarEmail(Email email)
        {
            if (email == null)
                throw new AppValidationException("Prometemos que não vamos enviar spam, mas precisamos de um endereço de email válido.");
        }

        public void ValidarSenha(Senha senha)
        {
            if (senha == null)
                throw new AppValidationException("Senha é obrigatória.");
        }

        public void AlterarNome(string novoNome)
        {
            GarantirAtivo();
            ValidarNome(novoNome);
            Nome = novoNome;
        }

        public void AlterarEmail(Email novoEmail)
        {
            GarantirAtivo();
            Email = novoEmail;
        }

        public void AlterarSenha(Senha novaSenha)
        {
            GarantirAtivo();
            Senha = novaSenha;
        }

        public void AlterarTipoUsuario(TipoUsuario novoTipo)
        {
            GarantirAtivo();

            if (TipoUsuario == novoTipo)
                throw new AppDomainException("O usuário já possui esse tipo.");

            TipoUsuario = novoTipo;
            AtualizarPlanoComBaseNoTipo();
        }

        public bool IsADM()
        {
            return TipoUsuario == TipoUsuario.Administrador;
        }

        public void AlterarPlano(PlanoUsuario novoPlano)
        {
            GarantirAtivo();
            if (Plano == novoPlano)
                throw new AppDomainException("Esse plano já está ativo na sua conta.");

            Plano = novoPlano;
        }

        private void AtualizarPlanoComBaseNoTipo()
        {
            Plano = TipoUsuario == TipoUsuario.Administrador
                ? PlanoUsuario.Premium
                : PlanoUsuario.Gratuito;
        }

        public bool IsPremium()
        {
            return Plano == PlanoUsuario.Premium;
        }        
    }
}
