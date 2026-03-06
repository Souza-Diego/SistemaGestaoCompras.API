namespace SistemaGestaoCompras.Domain.ValueObjects
{
    public class Dinheiro
    {
        public decimal Valor { get; }
        public static Dinheiro Zero => new Dinheiro(0);
        public Dinheiro(decimal valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor não pode ser negativo");
            }
            Valor = decimal.Round(valor,2);
        }
        
        public static Dinheiro operator +(Dinheiro a, Dinheiro b)
        {
            return new Dinheiro(a.Valor + b.Valor);
        }

        public static Dinheiro operator *(Dinheiro a, decimal quantidade)
        {
            return new Dinheiro(quantidade * a.Valor);
        }
    }
}
