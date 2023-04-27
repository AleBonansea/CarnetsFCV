using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Equipos : System.Web.UI.Page
    {
        Logica.EquipoLOG clubes = new Logica.EquipoLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rolId"] != null)
            {
                int clubId = Int32.Parse((string)Session["clubId"]);
                CargarGrilla(clubId);

            }
            else
            {
                Response.Redirect("Ingreso.aspx");
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }

        public void CargarGrilla(int clubId)
        {
            gvEquipos.DataSource = clubes.getTotalEquipos(clubId);
            gvEquipos.DataBind();
        }


        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            int clubId = Int32.Parse((string)Session["clubId"]);
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                gvEquipos.DataSource = clubes.getBuscadorEquipos(txtBuscar.Text, clubId);
                gvEquipos.DataBind();
            }
            else
            {
                CargarGrilla(clubId);
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {

        }
    }
}