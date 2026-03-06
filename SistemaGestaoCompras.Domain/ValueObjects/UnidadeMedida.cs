using SistemaGestaoCompras.Domain.Enums;

namespace SistemaGestaoCompras.Domain.ValueObjects
{
    public class UnidadeMedida
    {
        public string Nome { get; }
        public string Simbolo { get; }
        public TipoUnidade Tipo { get; }
        public decimal FatorBase { get; }

        private UnidadeMedida(string nome, string simbolo, TipoUnidade tipo, decimal fatorBase)
        {
            Nome = nome;
            Simbolo = simbolo;
            Tipo = tipo;
            FatorBase = fatorBase;
        }

        public decimal Converter(decimal quantidade, UnidadeMedida unidadeDestino)
        {
            if (Tipo != unidadeDestino.Tipo)
                throw new InvalidOperationException("Não é possível converter entre unidades de tipos diferentes.");
            
            decimal quantidadeBase = quantidade * FatorBase;
            return quantidadeBase / unidadeDestino.FatorBase;
        }

        public static readonly UnidadeMedida Grama =
            new("Grama", "g", TipoUnidade.Massa, 1m);

        public static readonly UnidadeMedida Quilograma =
            new("Quilograma", "kg", TipoUnidade.Massa, 1000m);

        public static readonly UnidadeMedida Mililitro =
            new("Mililitro", "ml", TipoUnidade.Volume, 1m);

        public static readonly UnidadeMedida Litro =
            new("Litro", "l", TipoUnidade.Volume, 1000m);

        public static readonly UnidadeMedida Unidade =
            new("Unidade", "un", TipoUnidade.Contagem, 1m);
    }
}
