using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazoCartas
{
    public class Carta
    {
        public enum TipoPalo { Trébol = 1, Diamantes, Corazón, Pica }
        public enum TipoValor { As = 1, J = 11, Q, K };

        public int Numero { get; private set; }
        public TipoPalo Palo 
        {
            get
            {
                int paloNumero = Numero / 13;
                return (TipoPalo)(paloNumero+1);
            }
        }
        public TipoValor Valor
        {
            get 
            {
                int valorNumero = Numero % 13;
                return (TipoValor)(valorNumero+1);
            }
        }

        public Carta(int numero)
        {
            this.Numero = numero;
        }

        override public string ToString()
        {
            return $"{Numero,4} {Palo,10} {Valor,-10}";
        }
    }
}
