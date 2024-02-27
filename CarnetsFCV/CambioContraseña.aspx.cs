using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class CambioContraseña : System.Web.UI.Page
    {
        Logica.UsuarioLOG usuario = new Logica.UsuarioLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            int usuarioId = Int32.Parse((string)Session["usuarioId"]);

            if (txtContraseña.Text == txtRepetirContraseña.Text)
            {
                Entidades.Usuarios usuarioAModificar = usuario.getUsuarioById(usuarioId);

                usuarioAModificar.Contraseña = txtContraseña.Text;
                usuarioAModificar.PrimerIngreso = false;

                usuario.modificarContraseña(usuarioAModificar);

                Session.Abandon();
                Session.RemoveAll();
                Response.Cookies.Clear();
                Response.Redirect("Ingreso.aspx");
            }
            else
            {
                lblError.Text = "Las contraseñas ingresadas no coinciden";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }
    }
}