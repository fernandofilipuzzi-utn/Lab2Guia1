using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace MazoCartas
{
    public class Mazo
    {
        public Carta[] cartas = new Carta[52];
        int cantidad = 52;

        public const int Reverso=51;

        static Random azar = new Random();
        public Mazo()
        {
            for (int n = 0; n < cantidad; n++)
            {
                cartas[n] = new Carta(n);
            }
        }

        public Carta Extraer()
        {
            Carta carta = null;
            
            if (cantidad>0)
            {
                int nro = azar.Next(0, cantidad);
                carta = cartas[nro];
                cartas[nro] = cartas[--cantidad];
            }
            return carta;
        }
    }
}
