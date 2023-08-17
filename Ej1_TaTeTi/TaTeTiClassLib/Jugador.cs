using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaTeTiClassLib
{
    public class Jugador
    {
        public string Nombre { get; private set; }
        public  string Marca { get; private set; }
        TaTeTi partida;
        static Random azar = new Random();
        public int UltimaFila { get; private set; }
        public int UltimaColumna { get; private set; }

        public Jugador(TaTeTi partida, string marca, string nombre) 
        {
            Nombre = nombre;
            this.partida = partida;
            Marca = marca;
        }

        public bool Jugar(int fila, int columna) 
        {
            UltimaFila = fila;
            UltimaColumna = columna;
            return partida.MarcarTablero(Marca, fila, columna);
        }

        public bool Jugar()
        {
            int fila= azar.Next(0, 3);
            int columna = azar.Next(0, 3);
            
            return Jugar(fila, columna);
        }

        public bool VerificarGanador()
        {
            return partida.VerificarJugada(this);
        }
    }
}
