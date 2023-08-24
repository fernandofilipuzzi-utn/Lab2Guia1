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

        public enum TipoAccion { LLamar, Pasar, Retirarse, RetirarseYSeguir }
        public string Nombre { get; private set; }

        int[] apuestas = new int[3];

        Carta[] cartas = new Carta[2];
        int cantidadCartas = 0;
        public TipoAccion Accion{get; private set;}

        Poquer partida;

        static Random azar = new Random();
        
        public Jugador(Poquer partida, string nombre) 
        {
            Nombre = nombre;
            this.partida = partida;
        }

        public void Jugar(TipoAccion accion, int fichas)
        {
            Accion = accion;

            if( accion== TipoAccion.LLamar) 
            {
                apuestas[partida.Ronda-1]+= fichas;            
            }
        }


        public void Jugar()
        {
            //
            int tipoAccionInt=azar.Next(0, 4);
            Accion = (TipoAccion)tipoAccionInt;

            int apuesta = 0;
            if (Accion == TipoAccion.LLamar)
                apuesta = azar.Next(1,100);

            Jugar(Accion, apuesta);
        }

        public void RecibirCarta(Carta carta)
        {
            if (cantidadCartas < 2)
                cartas[cantidadCartas++] = carta;
        }

        public Carta VerCarta(int idx)
        {
            return cartas[idx];
        }
        public int VerApuestaRonda()
        {
            return apuestas[partida.Ronda-1];
        }

        public int VerAcumulado()
        {
            int acumulado = 0;
            for(int n=0; n<partida.Ronda;n++)
                acumulado+=apuestas[n];
            return acumulado;
        }
    }
}
