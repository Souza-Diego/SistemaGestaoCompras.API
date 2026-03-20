using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.Exceptions;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class Produto : EntidadeAtiva
    {
        public string Nome { get; private set; }
        public Guid IdCategoria { get; private set; }
        public Guid? IdMarca { get; private set; }
        public UnidadeMedida UnidadeBase { get; private set; }
        public Guid? IdCriadoPorUsuario { get; private set; }
        public TipoProduto Tipo { get; private set; }
        public decimal? QuantidadeBase { get; private set; }

        protected Produto()
        {
            Nome = null!;
            UnidadeBase = null!;
        }

        public Produto(
            string nome,
            Guid idCategoria,
            UnidadeMedida unidadeBase,
            TipoProduto tipo,
            Guid? idMarca,
            Guid? idCriadoPorUsuario,
            decimal? quantidadeBase)
        {
            ValidarNome(nome);
            ValidarCategoria(idCategoria);
            ValidarUnidadeBase(unidadeBase);
            ValidarQuantidade(quantidadeBase);

            if (tipo == TipoProduto.Personalizado && idCriadoPorUsuario == null)
                throw new AppDomainException("Produto personalizado deve possuir um usuário criador.");

            if (tipo == TipoProduto.Global && idCriadoPorUsuario != null)
                throw new AppDomainException("Produto global não deve possuir usuário criador.");

            Nome = nome.Trim();
            IdCategoria = idCategoria;
            UnidadeBase = unidadeBase;
            IdMarca = idMarca;
            IdCriadoPorUsuario = idCriadoPorUsuario;
            Tipo = tipo;
            QuantidadeBase = quantidadeBase;
        }

        public void AlterarNome(string novoNome, Guid usuarioId)
        {
            GarantirPodeAlterar(usuarioId);
            ValidarNome(novoNome);
            Nome = novoNome.Trim();
        }

        public void AlterarCategoria(Guid novoIdCategoria, Guid usuarioId)
        {
            GarantirPodeAlterar(usuarioId);
            ValidarCategoria(novoIdCategoria);
            IdCategoria = novoIdCategoria;
        }

        public void AlterarMarca(Guid? idMarca, Guid usuarioId)
        {
            GarantirPodeAlterar(usuarioId);
            IdMarca = idMarca;
        }

        public void AlterarUnidade(UnidadeMedida novaUnidade, Guid usuarioId)
        {
            GarantirPodeAlterar(usuarioId);
            ValidarUnidadeBase(novaUnidade);
            UnidadeBase = novaUnidade;
        }

        public void AlterarQuantidade(decimal? novaQuantidade, Guid usuarioId)
        {
            GarantirPodeAlterar(usuarioId);
            ValidarQuantidade(novaQuantidade);
            QuantidadeBase = novaQuantidade;
        }

        public void Desativar(Guid usuarioId)
        {
            GarantirPodeAlterar(usuarioId);
            Desativar();
        }

        public void Ativar(Guid usuarioId)
        {
            GarantirPodeAlterar(usuarioId);
            Ativar();
        }

        private void GarantirPodeAlterar(Guid usuarioId)
        {
            GarantirAtivo();

            if (IsPersonalizado() && IdCriadoPorUsuario != usuarioId)
                throw new AppDomainException("Você não tem permissão para alterar este produto.");

            if (IsGlobal())
                throw new AppDomainException("Produto global só pode ser alterado por administrador.");
        }

        public bool IsGlobal() => Tipo == TipoProduto.Global;
        public bool IsPersonalizado() => Tipo == TipoProduto.Personalizado;

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new AppDomainException("O nome do produto não pode ser vazio.");
        }

        private void ValidarCategoria(Guid idCategoria)
        {
            if (idCategoria == Guid.Empty)
                throw new AppDomainException("Categoria é obrigatória.");
        }

        private void ValidarUnidadeBase(UnidadeMedida unidadeBase)
        {
            if (unidadeBase is null)
                throw new AppDomainException(nameof(unidadeBase));
        }

        private void ValidarQuantidade(decimal? quantidade)
        {
            if (quantidade.HasValue && quantidade <= 0)
                throw new AppDomainException("Quantidade deve ser maior que zero.");
        }
    }
}