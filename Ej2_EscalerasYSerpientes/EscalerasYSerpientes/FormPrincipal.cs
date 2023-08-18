using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

using EscalerasYSerpientesClassLib;
using EscalerasYSerpientesDesktop.Modelo;

namespace EscalerasYSerpientesDesktop
{ 
    public partial class FormPrincipal : Form

    {
        EscalerasYSerpientes nuevo;

        ArrayList partidas = new ArrayList();
     

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDatos fDato = new FormDatos();

            if (fDato.ShowDialog() == DialogResult.OK)
            {
                string jugador = fDato.tbNombre.Text;
                int cantidad = Convert.ToInt32( fDato.nudCantidad.Value);

                nuevo = new EscalerasYSerpientes(jugador, cantidad);

                for (int m = 0; m < nuevo.CantidadElementos; m++)
                {
                    Elemento elemento = nuevo.VerElemento(m);
                    string linea = $"   {elemento.VerDescripcion()} ";
                    listBox1.Items.Add(linea);
                }

                listBox1.Items.Add("---");

                btnJugar.Enabled = true;
            }            
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (nuevo.HaFinalizado() == false)
            {
                nuevo.Jugar();

                for (int n = 0; n < nuevo.CantidadJugadores; n++)
                {
                    Jugador jugador = nuevo.VerJugador(n);

                    string linea = $">{jugador.Nombre} se movió desde la posición: {jugador.PosicionAnterior}" +
                                    $"a la posición {jugador.PosicionActual} ({jugador.Avance})";

                    listBox1.Items.Add(linea);

                    #region pintando las escaleras y los bichos que lo mordieron
                    for (int m = 0; m < jugador.VerCantidadQuienes; m++)
                    {
                        Elemento quien = jugador.VerPorQuien(n);
                        if (quien != null)
                        {
                            linea = $"   Afectador por: {quien.VerDescripcion()} ";
                            listBox1.Items.Add(linea);
                        }
                    }
                    #endregion
                }

                listBox1.Items.Add("------");
            }
            else
            {
                MessageBox.Show("Finalizó!");
               
                for (int n = 0; n < nuevo.CantidadJugadores; n++)
                {
                    Jugador jug = (Jugador)(nuevo.VerJugador(n));
                    if (jug.HaLLegado)
                        AgregarPartida(jug.Nombre);
                }
            }
        }

        private void btnListarHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial fHistorial = new FormHistorial();

            foreach (Partida p in ListarPartidasOrdenadas())
                fHistorial.listBox1.Items.Add($"{ p.Ganador}  {p.Ganadas}");

            fHistorial.ShowDialog();

            fHistorial.Dispose();
        }

        //

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

        public void AgregarPartida(string nombre)
        {
            #region buscar el registro primero!
            Partida buscado = null;
            for (int n = 0; n < partidas.Count && buscado == null; n++)
            {
                Partida p = (Partida)partidas[0];
                if (p.Ganador == nombre)
                    buscado = p;
            }
            #endregion

            #region lo actualizo silo encuentro sono lo agrego 
            if (buscado != null)
                buscado.Ganadas++;
            else
                partidas.Add(new Partida(nombre, 1));
            #endregion
        }
    }
}
