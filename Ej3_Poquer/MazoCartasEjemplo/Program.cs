using MazoCartas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Mazo mazo=new Mazo();
            for (int n = 0; n < 52; n++)
            {
                Carta carta = mazo.Extraer();
                Console.WriteLine(carta);
            }
            Console.ReadKey();
        }
    }
}
