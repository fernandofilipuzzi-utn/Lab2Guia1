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

        public void IniciarRondaApuestas()
        {
            if (Ronda == 0)
            {
                #region iniciando el juego
                for (int n = 0; n < CantidadJugadores; n++)
                {
                    Jugador jug = (Jugador)jugadores[n];
                    jug.RecibirCarta(mazo.Extraer());
                    jug.RecibirCarta(mazo.Extraer());
                }
                Ronda = 1; 
                
                //siguen las apuestas de la ronda 1

                #endregion
            }
            else if(Ronda==1)
            {
                #region terminada la ronda 1 de apuestas
                CantCartasComunitarias = 3;
                for (int n = 0; n < CantCartasComunitarias; n++)
                {
                    cartas[n] = mazo.Extraer();
                }
                Ronda = 2;

                //sigue la apuesta de la ronda 2

                #endregion
            }
            else if (Ronda == 2)
            {
                #region terminada la ronda 2 de apuestas
                cartas[CantCartasComunitarias++] = mazo.Extraer();
                Ronda=3;

                //sigue la apuesta de la ronda 3

                #endregion
            }
            else if (Ronda == 3)
            {
                #region terminada la ronda 3 de apuestas

                cartas[CantCartasComunitarias++] = mazo.Extraer();

                //sigue ver las manos
                Ronda = 4;

                #endregion
            }
        }

        public void Jugar(Jugador.TipoAccion accion,int fichas)
        {
            if (FinDelJugo==false)
            {
                #region apuestan los jugadores
                
                for (int n = 0; n < CantidadJugadores; n++)
                {
                    Jugador jug = (Jugador)jugadores[n];

                    if (n == 0)//humano
                    {
                        jug.Jugar(accion, fichas);
                    }
                    else //jugadores virtuales
                    {
                        jug.Jugar();
                    }
                }
                #endregion

                #region el crupier verifica el ok de todas las apuestas
                VerificarApuestas();
                if (CompletoRonda == true)
                {
                    VerificarFinDelJuego();
                    if (FinDelJugo == false)
                        IniciarRondaApuestas();
                }
                else
                {
                    //sino completaron, marcar a quien volver a pedirles completar
                    int maxima = MayorApuesta();
                    for (int n = 0; n < CantidadJugadores; n++)
                    {
                        Jugador jug = (Jugador)jugadores[n];
                        jug.CompletoRonda = jug.Accion == Jugador.TipoAccion.Pasar ||
                                                    (jug.Accion == Jugador.TipoAccion.LLamar &&
                                                    jug.VerApuestaRonda() != maxima);
                    }
                }
                #endregion
            }
        }


        /// <summary>
        /// verifico que las apuestas esten bien
        /// </summary>
        public bool CompletoRonda { get; set; } = false;
        private void VerificarApuestas()
        {
            int maxima = MayorApuesta();

            bool todosPasan = true;
            bool hanIgualado = true;
            for (int n=0; n<CantidadJugadores && (todosPasan||hanIgualado); n++)
            {
                Jugador jug = (Jugador)jugadores[n];
                if (jug.Accion < Jugador.TipoAccion.Retirarse)
                {
                    //si todos check check?
                    todosPasan &= jug.Accion == Jugador.TipoAccion.Pasar;

                    //que si apostaron hayan igualado
                    hanIgualado &= (jug.Accion == Jugador.TipoAccion.LLamar && jug.VerApuestaRonda() == maxima) ||
                                    jug.Accion > Jugador.TipoAccion.LLamar; //igualaron o otra cosa
                }
            }

            /* 
                de los que no se han retirado:
                todos pasan (check)? o
                todos han igualado? 
             */
            CompletoRonda=todosPasan || hanIgualado;
        }

        public bool FinDelJugo { get; private set; } = false;
        private void VerificarFinDelJuego()
        {
            bool fin = false;

            int queNoSeRetiren=0;
            for (int n = 0; n < CantidadJugadores; n++)
            {
                Jugador jug = (Jugador)jugadores[n];
                
                if (jug.Accion == Jugador.TipoAccion.RetirarseYSeguir)
                    queNoSeRetiren++;
            }

            /*
                queda un solo jugador - o apostando, o pasan y siguen , o checan
             */
            fin|= queNoSeRetiren == CantidadJugadores-1;

            FinDelJugo = fin;
        }

        public Carta VerCartaComunicaria(int idx)
        {
            Carta carta = null;

            if (idx < CantCartasComunitarias)
            {
                carta = (Carta)(cartas[idx]);
            }

            return carta;
        }

        public Jugador VerJugador(int nro)
        {
            Jugador jug = null;
            
            if(nro<CantidadJugadores)
                jug=(Jugador)(jugadores[nro]);

            return jug;
        }

        public int MayorApuesta()
        {
            int mayor = VerJugador(0).VerApuestaRonda();
            for (int n = 1; n < CantidadJugadores; n++)
            {
                int apuesta = VerJugador(n).VerApuestaRonda();
                if (mayor < apuesta)
                    mayor = apuesta;
            }
            return mayor;
        }
    }
}
