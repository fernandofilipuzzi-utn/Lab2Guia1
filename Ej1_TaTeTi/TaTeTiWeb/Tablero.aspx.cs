using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TaTeTiClassLib;
using TaTeTiWeb.Modelo;

namespace TaTeTiWeb
{
    public partial class Tablero : System.Web.UI.Page
    {       
        Button[,] btnMatrix = new Button[3, 3];
   
        protected void Page_Init(object sender, EventArgs e)
        {
            Sistema sistema = Session["sistema"] as Sistema;

            if (sistema == null)
            {
                sistema = new Sistema();
                Session["sistema"] = sistema;
            }

            #region iniciando matrix de botones                        
            btnMatrix[0, 0] = btn1;
            btnMatrix[0, 1] = btn2;
            btnMatrix[0, 2] = btn3;
            btnMatrix[1, 0] = btn4;
            btnMatrix[1, 1] = btn5;
            btnMatrix[1, 2] = btn6;
            btnMatrix[2, 0] = btn7;
            btnMatrix[2, 1] = btn8;
            btnMatrix[2, 2] = btn9;
            #endregion

            if (sistema.Juego == null || sistema.Juego.HaFinalizado() == true)
                Response.Redirect("./NuevoJuego.aspx");

            plTablero.Enabled = sistema.Juego.HaFinalizado() == false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {          
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("./NuevoJuego.aspx");
        }
                
        protected void btnJugar_Click(object sender, EventArgs e)
        {
            Sistema sistema = Session["sistema"] as Sistema;

            int fila, columna;
            ConvertButtonToMap(sender as Button, out fila, out columna);

            if (sistema.Juego.Jugador1.Jugar(fila, columna) == true)
            {
                btnMatrix[sistema.Juego.Jugador1.UltimaFila,
                          sistema.Juego.Jugador1.UltimaColumna].Style["background-image"] = "url('./Resources/O.png')";

                while (sistema.Juego.Jugador2.Jugar() == false) ;
                btnMatrix[sistema.Juego.Jugador2.UltimaFila,
                           sistema.Juego.Jugador2.UltimaColumna].Style["background-image"] = "url('./Resources/X.png')";
            }
            else
            {
                string script = $"alert('Vuelva a marcar!');";
                ClientScript.RegisterStartupScript(this.GetType(), "MensajeEmergente", script, true);
            }

            if (sistema.Juego.HaFinalizado() == true)
            {
                Jugador g = sistema.Juego.HayGanador();
                if (g != null)
                {
                    string script = $"alert('{g.Nombre}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "MensajeEmergente", script, true);

                    sistema.AgregarPartida(g.Nombre);
                }
                else
                {
                    string script = "alert('Empate');";
                    ClientScript.RegisterStartupScript(this.GetType(), "MensajeEmergente", script, true);
                }

                plTablero.Enabled = false;
            }
        }

        protected void btnVerHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Historial.aspx");
        }
        
        //

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
    }
}