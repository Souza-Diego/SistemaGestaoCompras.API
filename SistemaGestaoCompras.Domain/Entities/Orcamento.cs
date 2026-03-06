using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Entities
{
    public class Orcamento : Entidade
    {        
        public Guid IdUsuario { get; private set; }
        public int Ano { get; private set; }
        public int Mes { get; private set; }
        public Dinheiro ValorPlanejado { get; private set; }

        protected Orcamento()
        {
            ValorPlanejado = null!;
        }

        public Orcamento(Guid idUsuario, int ano, int mes, Dinheiro valorPlanejado)
        {            
            IdUsuario = idUsuario;
            Ano = ano;            
            Mes = mes;
            ValorPlanejado = valorPlanejado;
        }

        public void AlterarValor(Dinheiro novoValor)
        {
            ValorPlanejado = novoValor;
        }
    }
}
