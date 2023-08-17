
using System.Collections;

namespace EscalerasYSerpientesClassLib

{
    public class EscalerasYSerpientes
    {
        ArrayList jugadores = new ArrayList();
        ArrayList elementos = new ArrayList();

        public int CantidadJugadores { get{ return jugadores.Count; } }
        public int CantidadElementos { get { return elementos.Count; } }

        public EscalerasYSerpientes(int cantJugadores) : this("Máquina 1", cantJugadores)
        {
        }

        public EscalerasYSerpientes(string Nombre, int cantJugadores)
        {
            jugadores.Add(new Jugador(Nombre));

            for (int n = 2; n <= cantJugadores; n++)
            {
                jugadores.Add(new Jugador("Máquina " + n));
            }

            for (int n = 1; n <= 7; n++)
            {
                elementos.Add(new Elemento(Elemento.TipoElemento.Escalera));
                elementos.Add(new Elemento(Elemento.TipoElemento.Serpiente));
            }
        }

        public void Jugar()
        {
            foreach (Jugador jugador in jugadores)
            {
                jugador.Mover();

                foreach (Elemento elemento in elementos)
                {
                    elemento.Evaluar(jugador);
                }
            }
        }

        public Jugador VerJugador(int idx)
        {
            return (Jugador)jugadores[idx];
        }
        public Elemento VerElemento(int idx)
        {
            return (Elemento)elementos[idx];
        }


      
        public bool HaFinalizado()
        {
            bool haFinalizado=false;
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.HaLLegado==true)
                {
                    haFinalizado |= true;
                }
            }
            return haFinalizado;
        }
    }
}
