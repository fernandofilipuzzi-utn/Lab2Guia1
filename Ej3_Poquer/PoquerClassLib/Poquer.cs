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

        public void Jugar(Jugador.TipoAccion accion,int fichas)
        {
            if (FinDelJugo==false)
            {
                #region apuestan los jugadores
                ((Jugador)jugadores[0]).Jugar(accion, fichas);
                for (int n = 1; n < CantidadJugadores; n++)
                {
                    ((Jugador)jugadores[n]).Jugar();
                }
                #endregion

                #region el crupier verifica el ok de todas las apuestas
                VerificarApuestas();
                if (CompletoRonda == true)
                {
                    VerificarFinDelJuego();
                    if(FinDelJugo==false)
                        IniciarRondaApuestas();
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
            return (Carta)(cartas[idx]);
        }

        public Jugador VerJugador(int nro)
        {
            return (Jugador)(jugadores[nro]);
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
