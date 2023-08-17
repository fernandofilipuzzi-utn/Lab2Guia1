using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TaTeTiClassLib;
using System.Collections;
using TaTeTiDesktop.Modelo;

namespace TaTeTiDesktop
{
    public partial class FormPrincipal : Form
    {
        TaTeTi nuevo;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        Button[,] btnMatrix = new Button[3, 3];
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            btnMatrix[0, 0] = btn1;
            btnMatrix[0, 1] = btn2;
            btnMatrix[0, 2] = btn3;
            btnMatrix[1, 0] = btn4;
            btnMatrix[1, 1] = btn5;
            btnMatrix[1, 2] = btn6;
            btnMatrix[2, 0] = btn7;
            btnMatrix[2, 1] = btn8;
            btnMatrix[2, 2] = btn9;
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            
            int fila, columna;

            ConvertButtonToMap(sender as Button, out fila, out columna);

            if (nuevo.Jugador1.Jugar(fila, columna) == true)
            {
                btnMatrix[nuevo.Jugador1.UltimaFila, nuevo.Jugador1.UltimaColumna].ImageIndex = 1;

                while (nuevo.Jugador2.Jugar() == false) ;
                btnMatrix[nuevo.Jugador2.UltimaFila, nuevo.Jugador2.UltimaColumna].ImageIndex = 2;
            }
            else
            {
                Text = "vuelva!";
            }

            if (nuevo.HaFinalizado() == true)
            {
                Jugador g = nuevo.HayGanador();
                if (g != null)
                {
                    MessageBox.Show(g.Nombre);

                    AgregarPartida(g.Nombre);
                }
                else
                    MessageBox.Show("Empate");

                plTablero.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDatos fDato = new FormDatos();

            if (fDato.ShowDialog() == DialogResult.OK)
            {
                nuevo = new TaTeTi(fDato.tbNombre.Text);

                //repinto el tablero
                for (int f = 0; f < 3; f++)
                    for (int c = 0; c < 3; c++)
                        btnMatrix[f, c].ImageIndex = 0;
            }
            plTablero.Enabled = true;
        }
        
        private void ConvertButtonToMap(Button sender, out int renglon, out int columna)
        {
            renglon = 0;
            columna = 0;
            switch (sender.TabIndex)
            {
                case 1: { renglon = 0; columna = 0; } break;
                case 2: { renglon = 0; columna = 1; } break;
                case 3: { renglon = 0; columna = 2; } break;
                case 4: { renglon = 1; columna = 0; } break;
                case 5: { renglon = 1; columna = 1; } break;
                case 6: { renglon = 1; columna = 2; } break;
                case 7: { renglon = 2; columna = 0; } break;
                case 8: { renglon = 2; columna = 1; } break;
                case 9: { renglon = 2; columna = 2; } break;
            }
        }

        ArrayList partidas = new ArrayList();
        public void AgregarPartida(string nombre)
        {
            //buscar el registro
            Partida buscado = null;
            for (int n = 0; n < partidas.Count && buscado==null; n++)
            {
                Partida p = (Partida)partidas[0];
                if (p.Ganador == nombre)
                    buscado = p;
            }

            if (buscado != null)
                buscado.Ganadas++;
            else
                partidas.Add(new Partida(nombre, 1));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHistorial fHistorial = new FormHistorial();

            foreach (Partida p in ListarPartidasOrdenadas())
                fHistorial.listBox1.Items.Add($"{ p.Ganador}  {p.Ganadas}");

            fHistorial.ShowDialog();

            fHistorial.Dispose();
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
