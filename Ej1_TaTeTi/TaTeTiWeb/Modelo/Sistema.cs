using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;

using TaTeTiClassLib;

namespace TaTeTiWeb.Modelo
{
    public class Sistema
    {
        TaTeTi nuevo;
        ArrayList partidas = new ArrayList();

        public void CrearNuevoJuego(string nombre)
        {
            nuevo = new TaTeTi(nombre);
        }

        public TaTeTi Juego
        {
            get 
            {
                return nuevo;
            }
        }

        public void AgregarPartida(string nombre)
        {
            //buscar el registro
            Partida buscado = null;
            for (int n = 0; n < partidas.Count && buscado == null; n++)
            {
                Partida p = (Partida)partidas[n];
                if (p.Ganador == nombre)
                    buscado = p;
            }

            if (buscado != null)
                buscado.Ganadas++;
            else
                partidas.Add(new Partida(nombre, 1));
        }

        public ArrayList ListarPartidasOrdenadas()
        {
            for (int n = 0; n < partidas.Count - 1; n++)
            {
                for (int m = 0; m < partidas.Count - 1; m++)
                {
                    Partida p = (Partida)partidas[n];
                    Partida q = (Partida)partidas[m];

                    if (p.Ganadas < q.Ganadas)
                    {
                        object aux = partidas[n];
                        partidas[n] = partidas[m];
                        partidas[m] = aux;
                    }
                }
            }
            return partidas;
        }
    }
}