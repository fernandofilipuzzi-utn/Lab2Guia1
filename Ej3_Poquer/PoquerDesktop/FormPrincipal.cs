using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PoquerClassLib;
using System.Collections;
using PoquerDesktop.Modelo;
using MazoCartas;

namespace PoquerDesktop
{
    public partial class FormPrincipal : Form
    {
        Poquer nuevo;
        ArrayList partidas = new ArrayList();

        public FormPrincipal()
        {
            InitializeComponent();
        }
                
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDatos fDato = new FormDatos();

            if (fDato.ShowDialog() == DialogResult.OK)
            {
                string nombreHumano = fDato.tbNombre.Text;
                int cantidadJugadores = Convert.ToInt32(fDato.nupCantidad.Value);
                nuevo = new Poquer(nombreHumano, cantidadJugadores);

                nuevo.IniciarRonda();

                PintarJugadores();
                PintarMesa();
            }
            plTablero.Enabled = true;
        }
        
        

        private void btnListarHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial fHistorial = new FormHistorial();

            foreach (Partida p in ListarPartidasOrdenadas())
                fHistorial.listBox1.Items.Add($"{ p.Ganador}  {p.Ganadas}");

            fHistorial.ShowDialog();

            fHistorial.Dispose();
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

        private void button4_Click(object sender, EventArgs e)
        {
            int apuesta = Convert.ToInt32(tbrApuestaJugador3.Value);
            bool haVerifcado=nuevo.Jugar(Jugador.TipoAccion.LLamar, apuesta);

            if (haVerifcado == false)
                MessageBox.Show("complete la apuesta");

            PintarJugadores();
            PintarMesa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nuevo.Jugar(Jugador.TipoAccion.Pasar,0);
            PintarJugadores();
            PintarMesa();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nuevo.Jugar(Jugador.TipoAccion.RetirarseYSeguir, 0);
            PintarJugadores();
            PintarMesa();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            nuevo.Jugar(Jugador.TipoAccion.Retirarse, 0);
            PintarJugadores();
            PintarMesa();
        }

        private void tbrApuestaJugador3_ValueChanged(object sender, EventArgs e)
        {
            lbLLamarJugador3.Text = tbrApuestaJugador3.Value.ToString();
            PintarJugadores();
            PintarMesa();
        }

        private void PintarMesa()
        {
            for (int n = 0; n < nuevo.CantCartasComunitarias; n++)
            {
                switch (n)
                {
                    case 1: btn1.ImageIndex = nuevo.VerCartaComunicaria(n).Numero + 1; break;
                    case 2: btn1.ImageIndex = nuevo.VerCartaComunicaria(n).Numero + 1; break;
                    case 3: btn1.ImageIndex = nuevo.VerCartaComunicaria(n).Numero + 1; break;
                    case 4: btn1.ImageIndex = nuevo.VerCartaComunicaria(n).Numero + 1; break;
                    case 5: btn1.ImageIndex = nuevo.VerCartaComunicaria(n).Numero + 1; break;
                }
            }
        }

        private void PintarJugadores()
        {
            for (int n = 0; n < nuevo.CantidadJugadores; n++)
            {
                Jugador jug = nuevo.VerJugador(n);

                switch (n)
                {
                    case 0:
                        {
                            lbJugador3.Text = jug.Nombre;
                            lbCantidad3.Text = jug.VerAcumulado().ToString();

                            btn1Jugador3.ImageIndex = jug.VerCarta(0).Numero + 1;
                            btn2Jugador3.ImageIndex = jug.VerCarta(1).Numero + 1;
                        }
                        break;
                    case 1:
                        {
                            lbJugador1.Text = jug.Nombre;
                            lbCantidad1.Text = jug.VerAcumulado().ToString();
                            btn1Jugador1.ImageIndex = 0;
                            btn2Jugador1.ImageIndex = 0;
                        }
                        break;
                    case 2:
                        {
                            lbJugador2.Text = jug.Nombre;
                            lbCantidad2.Text = jug.VerAcumulado().ToString();
                            btn1Jugador2.ImageIndex = 0;
                            btn2Jugador2.ImageIndex = 0;
                        }
                        break;
                }
            }
        }
    }
}
