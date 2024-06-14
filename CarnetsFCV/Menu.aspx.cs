using Entidades.Enums;
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
        Logica.UsuarioLOG usuario = new Logica.UsuarioLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rolId"] != null)
            {
                string nombreUsuario = Session["usuario"].ToString();

                List<Entidades.Dto.UsuarioDto> rolesUsuario = usuario.getRoles(nombreUsuario);

                foreach (var rol in rolesUsuario)
                {
                    switch (rol.RolId)
                    {
                        case (int)RolesEnum.Entrenador:
                            carnetEntrenador.Visible = true;
                            break;

                        case (int)RolesEnum.Arbitro:
                            carnetArbitro.Visible = true;
                            break;

                        case (int)RolesEnum.Jugador:
                            carnetJugador.Visible = true;
                            break;
                    }
                }

                int rolId = Int32.Parse((string)Session["rolId"]);


                switch (rolId)
                {
                    case 1:
                        btnEquipos.Visible = false;
                        btnCarnet.Visible = false;
                        btnJugadores.Visible = false;
                        break;

                    case 2:
                        btnArbitros.Visible = false;
                        btnClubes.Visible = false;
                        btnCarnet.Visible = false;
                        btnEntrenadores.Visible = false;
                        btnAjustes.Visible = false;
                        btnHabilitaciones.Visible = false;
                        break;

                    case (3):
                        btnArbitros.Visible = false;
                        btnClubes.Visible = false;
                        btnEntrenadores.Visible = false;
                        btnEquipos.Visible = false;
                        btnJugadores.Visible = false;
                        btnAjustes.Visible = false;
                        btnHabilitaciones.Visible = false;
                        break;

                    case (4):
                        btnArbitros.Visible = false;
                        btnClubes.Visible = false;
                        btnEntrenadores.Visible = false;
                        btnEquipos.Visible = false;
                        btnJugadores.Visible = false;
                        btnAjustes.Visible = false;
                        btnHabilitaciones.Visible = false;
                        break;

                    case (5):
                        btnArbitros.Visible = false;
                        btnClubes.Visible = false;
                        btnEntrenadores.Visible = false;
                        btnEquipos.Visible = false;
                        btnJugadores.Visible = false;
                        btnAjustes.Visible = false;
                        btnHabilitaciones.Visible = false;
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
            Response.Redirect("Jugadores.aspx");
        }

        protected void btnClubes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clubes.aspx");
        }

        protected void btnEquipos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Equipos.aspx");
        }

        protected void btnEntrenadores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entrenadores.aspx");
        }

        protected void btnArbitros_Click(object sender, EventArgs e)
        {
            Response.Redirect("Arbitros.aspx");
        }

        protected void carnetJugador_Click(object sender, EventArgs e)
        {
            int rolId = (int)RolesEnum.Jugador;
            Session["rolId"] = rolId.ToString();
            Response.Redirect("Carnets.aspx");
        }

        protected void carnetEntrenador_Click(object sender, EventArgs e) 
        {
            int rolId = (int)RolesEnum.Entrenador;
            Session["rolId"] = rolId.ToString();
            Response.Redirect("Carnets.aspx");
        }

        protected void carnetArbitro_Click(object sender, EventArgs e)
        {
            int rolId = (int)RolesEnum.Arbitro;
            Session["rolId"] = rolId.ToString();
            Response.Redirect("Carnets.aspx");
        }

        protected void btnCambioContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioContraseña.aspx");
        }

        protected void btnHabilitaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Habilitaciones.aspx");
        }

        protected void btnAjustes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ajustes.aspx");
        }
    }
}