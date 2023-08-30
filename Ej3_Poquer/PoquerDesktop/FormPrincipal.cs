using MazoCartas;
using PoquerClassLib;
using PoquerDesktop.Modelo;
using System;
using System.Collections;
using System.Windows.Forms;

namespace PoquerDesktop
{
    public partial class FormPrincipal : Form
    {
        Poquer nuevo;
        ArrayList partidas = new ArrayList();

        PictureBox[] pbxComunitarias = new PictureBox[5];

        Label[] lbNombres = new Label[3];
        Label[] lbApuestasAcumJ = new Label[5];
        Label[] lbAcciones = new Label[3];
        PictureBox[,] pbxCartasJ = new PictureBox[3, 2];

        public FormPrincipal()
        {
            InitializeComponent();
        }
                
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            pbxComunitarias[0] = pbxCarta1C;
            pbxComunitarias[1] = pbxCarta2C;
            pbxComunitarias[2] = pbxCarta3C;
            pbxComunitarias[3] = pbxCarta4C;
            pbxComunitarias[4] = pbxCarta5C;

            lbNombres[0] = lbNombreJ1;
            pbxCartasJ[0, 0] = pbxCarta1J1;
            pbxCartasJ[0, 1] = pbxCarta2J1;
            lbApuestasAcumJ[0] = lbApuestaAcumJ1;
            lbAcciones[0] = lbAccionJ1;

            lbNombreJ1.Text = "";
            lbApuestaAcumJ1.Text = "";
            lbAccionJ1.Text = "";

            lbNombres[1] = lbNombreJ2;
            pbxCartasJ[1, 0] = pbxCarta1J2;
            pbxCartasJ[1, 1] = pbxCarta2J2;
            lbApuestasAcumJ[1] = lbApuestaAcumJ2;
            lbAcciones[1] = lbAccionJ2;

            lbNombreJ2.Text = "";
            lbApuestaAcumJ2.Text = "";
            lbAccionJ2.Text = "";

            lbNombres[2] = lbNombreJ3;
            pbxCartasJ[2, 0] = pbxCarta1J3;
            pbxCartasJ[2, 1] = pbxCarta2J3;
            lbApuestasAcumJ[2] = lbApuestaAcumJ3;
            lbAcciones[2] = lbAccionJ3;

            lbNombreJ3.Text = "";
            lbApuestaAcumJ3.Text = "";
            lbAccionJ3.Text = "";
            lbLLamarJ3.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDatos fDato = new FormDatos();

            if (fDato.ShowDialog() == DialogResult.OK)
            {
                string nombreHumano = fDato.tbNombre.Text;
                int cantidadJugadores = Convert.ToInt32(fDato.nupCantidad.Value);
                
                nuevo = new Poquer(nombreHumano, cantidadJugadores);
                nuevo.IniciarRondaApuestas();

                PintarJugadores();
                PintarMesa();
            }

            plTablero.Enabled = true;
            btnJugar.Enabled = true;
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

        private void PintarMesa()
        {
            for (int n = 0; n < 5; n++)
            {
                int numero = Mazo.Reverso;
                if (n < nuevo.CantCartasComunitarias)
                {
                    Carta carta = nuevo.VerCartaComunicaria(n);
                    numero = carta.Numero;
                }
                pbxComunitarias[n].Image = imgLstCartas.Images[numero];
            }
        }

        private void PintarJugadores()
        {
            for (int n = 0; n < 3; n++)
            {
                if (n < nuevo.CantidadJugadores)
                {
                    Jugador jug = nuevo.VerJugador(n);

                    lbNombres[n].Text = jug.Nombre;
                    lbApuestasAcumJ[n].Text = jug.VerAcumulado().ToString("000");

                    if (jug.Accion > Jugador.TipoAccion.Nada)
                        lbAcciones[n].Text = jug.Accion.ToString();
                    else
                        lbAcciones[n].Text = "";

                    #region pintar cartas
                    for (int m = 0; m < 2; m++)
                    {
                        int numero = Mazo.Reverso;

                        #region pinta las cartas solo del jugador humano
                        if (n == 0)
                        {
                            Carta carta = jug.VerCarta(m);
                            numero = carta.Numero;
                        }
                        #endregion
                        pbxCartasJ[n, m].Image = imgLstCartas.Images[numero];
                    }
                    #endregion
                }
                else
                {
                    lbNombres[n].Text = "";
                    lbApuestasAcumJ[n].Text = "";
                    lbAcciones[n].Text = "";
                }
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            #region parseando acción
            Jugador.TipoAccion accion=Jugador.TipoAccion.Nada;
            int apuesta = 0;

            if (rbLLamar.Checked)
            {
                accion = Jugador.TipoAccion.LLamar;
                apuesta = Convert.ToInt32(tbrApuestaJ3.Value);
            }
            else if(rbPasar.Checked)
            {
                accion = Jugador.TipoAccion.Pasar;
            }
            else if(rbRetirarYSeguir.Checked)
            {
                accion = Jugador.TipoAccion.RetirarseYSeguir;
            }
            else if (rbRetirarse.Checked)
            {
                accion = Jugador.TipoAccion.Retirarse;
            }
            #endregion

            nuevo.Jugar(accion, apuesta);

            if (nuevo.CompletoRonda == false)
                MessageBox.Show("complete la apuesta");

            if (nuevo.FinDelJugo == true)
            {
                btnJugar.Enabled = false;
                MessageBox.Show("fin!");
            }

            PintarJugadores();
            PintarMesa();
        }

        private void tbrApuestaJ3_ValueChanged(object sender, EventArgs e)
        {
            lbLLamarJ3.Text = tbrApuestaJ3.Value.ToString("000");
        }

        private void pbxCartaC_MouseMove(object sender, MouseEventArgs e)
        {
            int numero = -1;

            var img=sender as PictureBox;

            if (img == pbxCarta1C) numero = 0;
            else if (img == pbxCarta2C) numero = 1;
            else if (img == pbxCarta3C) numero = 2;
            else if (img == pbxCarta4C) numero = 3;
            else if (img == pbxCarta5C) numero = 4;

            Carta carta = nuevo.VerCartaComunicaria(numero);
            if (carta!= null && numero >= 0)
                toolTip1.SetToolTip(img, carta.ToString());
        }

        private void pbxCartaJ1_MouseMove(object sender, MouseEventArgs e)
        {
            int numero = -1;
            var img = sender as PictureBox;
            if (img == pbxCarta1J1) numero = 0;
            else if (img == pbxCarta2J1) numero = 1;

            Carta carta = nuevo.VerJugador(0).VerCarta(numero);
            if (carta != null && numero>= 0)
                toolTip1.SetToolTip(img, carta.ToString());
        }
    }
}
