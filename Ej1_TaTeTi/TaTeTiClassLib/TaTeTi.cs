using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaTeTiClassLib
{
    public class TaTeTi
    {
        string[,] tablero;
        public Jugador Jugador1 { get; private  set; }
        public Jugador Jugador2 { get; private set; }

        public TaTeTi():this("Maquina 2")
        {
        }

        public TaTeTi(string Nombre) 
        {
            Jugador1 = new Jugador(this, "O", Nombre);
            Jugador2 = new Jugador(this, "X", "Maquina 1");

            InicializarTablero();
        }

        void InicializarTablero()
        {
            tablero = new string[3, 3];
            for (int n = 0; n < 3; n++)
                for (int m = 0; m < 3; m++)
                    tablero[n, m] = "";
        }

        public bool MarcarTablero(string marca, int fila, int columna)
        {
            bool marcado = tablero[fila, columna] == "";
            if (marcado) tablero[fila, columna] = marca;
            return marcado;
        }

        /// <summary>
        /// verifica si el jugador comleta linea
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public bool VerificarJugada(Jugador jugador)
        {
            //verificar filas
            bool esLinea = false;
            for (int fila = 0; fila < 3 && esLinea == false; fila++)
            {
                esLinea = true;
                for (int columna = 0; columna < 3 && esLinea == true; columna++)
                    esLinea &= tablero[fila, columna] == jugador.Marca;
            }

            //verificar columnas
            for (int columna = 0; columna < 3 && esLinea == false; columna++)
            {
                esLinea = true;
                for (int fila = 0; fila < 3 && esLinea == true; fila++)
                    esLinea &= tablero[fila, columna] == jugador.Marca;
            }

            //verificar diagonal
            if (esLinea == false)
            {
                esLinea = true;
                for (int n = 0; n < 3 && esLinea == true; n++)
                {
                    esLinea &= tablero[n, n] == jugador.Marca;
                }
            }

            //verificar diagonal invertida
            if (esLinea == false)
            {
                esLinea = true;
                for (int n = 0; n < 3 && esLinea == true; n++)
                {
                    esLinea &= tablero[n, 2 - n] == jugador.Marca;
                }
            }

            /*
            //verificar filas
            int cnt = 0;
            for (int fila = 0; fila < 3 && cnt<3; fila++)
            {
                cnt = 0;
                for (int columna = 0; columna < 3; columna++)
                {
                    if (tablero[fila, columna] == jugador.Marca) cnt++;
                }
            }

            //verifico columnas
            for (int columna = 0; columna < 3 && cnt < 3; columna++)
            {
                cnt = 0;
                for (int fila = 0; fila < 3; fila++)
                {
                    if (tablero[fila, columna] == jugador.Marca) cnt++;
                }
            }

            //diagonal
            if (cnt < 3)
            {
                cnt = 0;
                for (int n = 0; n < 3; n++)
                {
                    if (tablero[n, n] == jugador.Marca) cnt++;
                }
            }

            //diagonal invertida
            if (cnt < 3)
            {
                cnt = 0;
                for (int n = 0; n < 3; n++)
                {
                    if (tablero[n, 2 - n] == jugador.Marca) cnt++;
                }
            }
            */

            return esLinea;
        }

        public bool HaFinalizado()
        {
            int cnt = 0;
            for (int fila = 0; fila < 3; fila++)
                for (int columna = 0; columna < 3; columna++)
                    if (tablero[fila, columna] != "")
                        cnt++;

            return cnt == 8 || HayGanador()!=null;                        
        }

        public Jugador HayGanador()
        {
            Jugador ganador=null;
            bool j1 = Jugador1.VerificarGanador();
            bool j2 = Jugador2.VerificarGanador();

            if (j1 == true && j2 == false) ganador = Jugador1;
            else if (j2 == true && j1 == false) ganador = Jugador2;

            return ganador;
        }
    }
}
