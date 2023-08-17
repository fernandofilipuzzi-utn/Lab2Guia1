using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace EscalerasYSerpientesClassLib
{
    public class Jugador
    {
        public string Nombre { get; private set; }

        int posicion;
        public int PosicionActual 
        {
            get 
            {
                return posicion;
            }
            set {
                if(value<100)
                    posicion = value;
                else
                    posicion = 100;
            }
        }

        public int PosicionAnterior { get; private set; }
        public int Avance { get; private set; }
        public bool HaLLegado
        {
            get 
            {
                return PosicionActual == 100;
            }
        }

        static Random dado = new Random();

        public ArrayList porQuienesFueAfectado { get; private set; }
        public int CantidadAfectadores
        {
            get {
                return porQuienesFueAfectado.Count;
                    }
        }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            porQuienesFueAfectado = new ArrayList();
        }

        public void Mover()
        {
            porQuienesFueAfectado = new ArrayList();

            Avance = dado.Next(1, 6);

            PosicionAnterior = PosicionActual;
            PosicionActual += Avance;
        }

        public int VerCantidadQuienes 
        { get { return porQuienesFueAfectado.Count; } }
        public Elemento VerPorQuien(int idx)
        {
            Elemento quien = null;
            if (VerCantidadQuienes > 0 && VerCantidadQuienes < porQuienesFueAfectado.Count)
                quien = (Elemento)porQuienesFueAfectado[idx];

            return (Elemento)porQuienesFueAfectado[idx];
        }

        public void AgregarAfectador(Elemento e)
        {
            porQuienesFueAfectado.Add(e);
        }
    }
}
