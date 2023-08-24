using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using MazoCartas;

namespace PoquerClassLib
{
    public class Poquer
    {
        public Mazo mazo = new Mazo();

        ArrayList jugadores = new ArrayList();
        public int CantidadJugadores { get; private set; }

        public int Ronda{get; private set;}

        Carta[] cartas = new Carta[5];
        public int CantCartasComunitarias = 0;

        public Poquer(string nombre, int cantidadJugadores) 
        {
            Jugador nuevo = null;
            this.CantidadJugadores = cantidadJugadores;
            
            nuevo = new Jugador(this, nombre);
            jugadores.Add(nuevo);

            for (int n = 0; n < cantidadJugadores - 1; n++)
            {
                nuevo = new Jugador(this, "Máquina " + n);
                jugadores.Add(nuevo);
            }
        }

        public void IniciarRonda()
        {
            if (Ronda == 0)
            {
                for (int n = 0; n < CantidadJugadores; n++)
                {
                    Jugador jug = (Jugador)jugadores[n];
                    jug.RecibirCarta(mazo.Extraer());
                    jug.RecibirCarta(mazo.Extraer());
                }
                Ronda = 1; //pasa a la siguiente
            }
            else if(Ronda==1)
            {
                CantCartasComunitarias = 3;
                for (int n = 0; n < CantCartasComunitarias; n++)
                {
                    cartas[n] = mazo.Extraer();
                }
                Ronda = 2;
            }
            else if (Ronda == 2)
            {
                cartas[CantCartasComunitarias++] = mazo.Extraer();
                Ronda=3;
            }
            else if (Ronda == 3)
            {
                cartas[CantCartasComunitarias++] = mazo.Extraer();
            }
        }

        public bool Jugar(Jugador.TipoAccion accion,int fichas)
        {
            ((Jugador)jugadores[0]).Jugar(accion, fichas);

            //simula los otros jugadores
            for (int n=1; n<CantidadJugadores;n++)
            {
                ((Jugador)jugadores[n]).Jugar();
            }

            //busca que todos los jugadores jueguen hasta que igualen al humano o 
            //empaten o se retiren
            bool incluyeHumano = false;
            Jugador[] aSolicitar = this.VerificarApuestas();
            do
            {
                foreach (Jugador jug in aSolicitar)
                {
                    if (jug != jugadores[0])
                        jug.Jugar();
                }
                aSolicitar = this.VerificarApuestas();

                foreach (Jugador jug in aSolicitar)
                {
                    if (jug == jugadores[0])
                        incluyeHumano = true;
                }
            } while (incluyeHumano == true && aSolicitar.Length > 1 ||
                    incluyeHumano == false && aSolicitar.Length > 0);

            return incluyeHumano;
        }

        /// <summary>
        /// verifica que todas las apuestas esten completas.
        /// </summary>
        /// <returns></returns>
        public Jugador[] VerificarApuestas()
        {
            Jugador [] aSolicitar=new Jugador[0];

            //buscar mayor apuesta., dentro de los que están apostando
            Jugador mayor =null;
            for (int n = 0; n < CantidadJugadores; n++)
            {
                Jugador jug = (Jugador)jugadores[n];
                if (jug.Accion == Jugador.TipoAccion.LLamar)
                {
                    int apuesta = jug.VerApuestaRonda();

                    if (mayor == null || mayor.VerApuestaRonda()<apuesta)
                        mayor = (Jugador)(jugadores[n]);
                }
            }

            return aSolicitar;
        }


        public Carta VerCartaComunicaria(int idx)
        {
            return (Carta)(cartas[idx]);
        }

        public Jugador VerJugador(int nro)
        {
            return (Jugador)(jugadores[nro]);
        }
    }
}
