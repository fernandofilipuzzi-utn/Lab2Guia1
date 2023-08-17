using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EscalerasYSerpientesClassLib;

namespace EscalerasYSerpientesVista
{ 
    public partial class FormPrincipal : Form

    {
        EscalerasYSerpientes nuevo;

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

                    for (int m = 0; m < jugador.VerCantidadQuienes; m++)
                    {
                        Elemento quien = jugador.VerPorQuien(n);
                        linea = $"   Afectador por: {quien.VerDescripcion()} ";
                        listBox1.Items.Add(linea);
                    }
                }

                listBox1.Items.Add("------");
            }
            else
            {
                MessageBox.Show("Finalizó!");
            }
        }
    }
}
