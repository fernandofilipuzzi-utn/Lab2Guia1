using MazoCartas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PoquerClassLib
{
    public class Jugador
    {
        /*
         * llamar: debe igualar o aumentar.
         * pasar: check - todos deben pasar para continuar.
         * 
         */
        public enum TipoAccion { Nada, LLamar, Pasar, Retirarse, RetirarseYSeguir }
        public string Nombre { get; private set; }

        int[] apuestas = new int[3];

        Carta[] cartas = new Carta[2];
        int cantidadCartas = 0;
        public TipoAccion Accion{get; private set;}

        Poquer partida;

        static Random azar = new Random();

        public bool CompletoRonda { get; set; }

        public Jugador(Poquer partida, string nombre) 
        {
            Nombre = nombre;
            this.partida = partida;
            Accion = TipoAccion.Nada;
        }

        public void Jugar(TipoAccion accion, int fichas)
        {
            if (Accion < TipoAccion.RetirarseYSeguir)
            {
                Accion = accion;

                if (Accion == TipoAccion.LLamar)
                {
                    apuestas[partida.Ronda - 1] += fichas;
                }
            }
        }

        public void Jugar()
        {
            if (Accion < TipoAccion.RetirarseYSeguir)
            {
                int mayor = partida.MayorApuesta();

                int tipoAccionInt = azar.Next(1, 5);
                TipoAccion accion = (TipoAccion)tipoAccionInt;

                int apuesta = 0;

                #region simula la acción de apostar
                if (accion == TipoAccion.LLamar)
                {
                    int igualarOSubir = azar.Next(0, 2);
                    int actual = this.VerApuestaRonda();

                    if (igualarOSubir == 0)
                    {
                        //igualar
                        apuesta = mayor - actual;
                    }
                    else
                    {
                        //subir
                        int subir = azar.Next(1, 10);
                        apuesta = subir;
                    }
                }
                #endregion

                Jugar(accion, apuesta);
            }
        }

        public void RecibirCarta(Carta carta)
        {
            if (cantidadCartas < 2)
                cartas[cantidadCartas++] = carta;
        }

        public Carta VerCarta(int idx)
        {
            Carta carta = null;
            if (idx >= 0 && idx < 2)
            {
                carta = cartas[idx];
            }
            return carta;
        }
        public int VerApuestaRonda()
        {
            return apuestas[partida.Ronda-1];
        }

        public int VerAcumulado()
        {
            int acumulado = 0;
            for (int n = 0; n < partida.Ronda; n++)
            {
                acumulado += apuestas[n];
            }
            return acumulado;
        }
    }
}
