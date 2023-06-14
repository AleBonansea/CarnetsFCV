using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rolId"] != null)
            {

                int rolId = Int32.Parse((string)Session["rolId"]);


                switch (rolId)
                {
                    case 1:
                        btnJugadores.Visible = false;
                        btnEquipos.Visible = false;
                        break;

                    case 2:
                        btnArbitros.Visible = false;
                        btnClubes.Visible = false;
                        break;

                    case (3):
                        btnArbitros.Visible = false;
                        btnClubes.Visible = false;
                        btnEntrenadores.Visible = false;
                        btnEquipos.Visible = false;
                        btnJugadores.Visible = false;
                        break;

                }
            }
            else
            {
                Response.Redirect("Ingreso.aspx");
            }
            
        }


        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }

        protected void btnJugadores_Click(object sender, EventArgs e)
        {
            Server.Transfer("Jugadores.aspx");
        }

        protected void btnClubes_Click(object sender, EventArgs e)
        {
            Server.Transfer("Clubes.aspx");
        }

        protected void btnEquipos_Click(object sender, EventArgs e)
        {
            Server.Transfer("Equipos.aspx");
        }

        protected void btnEntrenadores_Click(object sender, EventArgs e)
        {
            Server.Transfer("Entrenadores.aspx");
        }

        protected void btnArbitros_Click(object sender, EventArgs e)
        {
            Server.Transfer("Arbitros.aspx");
        }
    }
}