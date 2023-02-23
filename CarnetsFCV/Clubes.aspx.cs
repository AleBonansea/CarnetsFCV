using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Clubes : System.Web.UI.Page
    {
        Logica.ClubLOG clubes = new Logica.ClubLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }

        public void CargarGrilla()
        {
            gvJugadores.DataBind();
            gvJugadores.DataSource = clubes.getTotalClubes();
        }
    }
}