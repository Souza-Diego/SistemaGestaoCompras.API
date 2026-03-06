using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class Produto
    {
        public Guid IdProduto { get; private set; }
        public string Nome { get; private set; }
        public Guid IdCategoria { get; private set; }
        public Guid? IdMarca { get; private set; }
        public UnidadeMedida UnidadeBase { get; private set; }
        public Guid? IdCriadoPorUsuario { get; private set; }
        public TipoProduto Tipo { get; private set; }
        public bool Ativo { get; private set; }

        protected Produto()
        {
            // Construtor protegido para uso do Entity Framework
            Nome = null!;
            UnidadeBase = null!;
        }

        public Produto(
            string nome,
            Guid idCategoria,
            UnidadeMedida unidadeBase,
            TipoProduto tipo,
            Guid? idMarca = null,
            Guid? idCriadoPorUsuario = null)
        {
            IdProduto = Guid.NewGuid();

            ValidarNome(nome);
            ValidarCategoria(idCategoria);
            ValidarUnidadeBase(unidadeBase);

            Nome = nome.Trim();
            IdCategoria = idCategoria;
            UnidadeBase = unidadeBase;
            IdMarca = idMarca;
            IdCriadoPorUsuario = idCriadoPorUsuario;
            Tipo = tipo;
            Ativo = true;
        }

        public void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto não pode ser vazio.");            
        }

        public void ValidarCategoria(Guid idCategoria)
        {
            if (idCategoria == Guid.Empty)
                throw new ArgumentException("Categoria é obrigatório.");            
        }

        public void ValidarUnidadeBase(UnidadeMedida unidadeBase)
        {
            if (unidadeBase is null)
                throw new ArgumentNullException(nameof(unidadeBase));
        }

        public void AlterarMarca(Guid? idMarca)
        {
            IdMarca = idMarca;
        }

        public void AlterarNome(string novoNome)
        {
            ValidarNome(novoNome);
            Nome = novoNome.Trim();
        }

        public void AlterarCategoria(Guid novoIdCategoria)
        {
            ValidarCategoria(novoIdCategoria);
            IdCategoria = novoIdCategoria;
        }        

        public void DesativarProduto()
        {
            Ativo = false;
        }

        public bool IsGlobal()
        {
            return Tipo == TipoProduto.Global;
        }

        public bool IsPersonalizado()
        {
            return Tipo == TipoProduto.Personalizado;
        }
    }
}
