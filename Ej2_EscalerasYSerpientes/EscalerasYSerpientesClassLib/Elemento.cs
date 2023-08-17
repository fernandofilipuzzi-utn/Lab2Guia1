using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalerasYSerpientesClassLib
{
    public class Elemento
    {
        public enum TipoElemento { Escalera, Serpiente}
       
        public TipoElemento tipo { get; private set; }

        public int PosicionInicial { get; private set; }
        public int PosicionFinal { get; private set; }

        static Random dado = new Random();

        public Elemento(TipoElemento tipo)
        {
            this.tipo = tipo;

            this.PosicionInicial = dado.Next(2,99);
            this.PosicionFinal = dado.Next(this.PosicionInicial, 99);
        }

        public void Evaluar(Jugador jugador)
        {
            if (tipo == TipoElemento.Escalera)
            {
                if (jugador.PosicionActual == PosicionInicial)
                {
                    jugador.PosicionActual = PosicionFinal;
                    jugador.AgregarAfectador(this);
                }
            }
            if (tipo == TipoElemento.Serpiente)
            {
                if (jugador.PosicionActual == PosicionFinal)
                {
                    jugador.PosicionActual = PosicionInicial;
                    jugador.AgregarAfectador(this);
                }
            }
        }

        public string VerDescripcion() 
        {
            string descripcion = "";

            descripcion = $"{tipo.ToString()} - Inicio: {PosicionInicial}, Fin:{PosicionFinal}";

            return descripcion;
        }
    }
}
