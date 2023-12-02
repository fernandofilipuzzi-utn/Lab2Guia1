using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaTeTiWeb.Modelo;

namespace TaTeTiWeb
{
    public partial class Historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sistema sistema = Session["sistema"] as Sistema;

            if (sistema == null)
            {
                sistema = new Sistema();
                Session["sistema"] = sistema;
            }

            ltwHistorial.DataSource = sistema.ListarPartidasOrdenadas();
            ltwHistorial.DataBind();
        }
    }
}