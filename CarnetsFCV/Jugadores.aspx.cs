using Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Jugadores : System.Web.UI.Page
    {
        Logica.JugadorLOG jugadores = new Logica.JugadorLOG();
        Logica.ClubLOG clubes = new Logica.ClubLOG();
        Logica.EquipoLOG equipos = new Logica.EquipoLOG();
        Logica.DivisionLOG division = new Logica.DivisionLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarClubes();
            //CargarDivisiones();
            //CargarRamas();
            //if (Session["rolId"] != null)
            //{
            //    int rolId = Int32.Parse((string)Session["rolId"]);
            //}
            //else
            //{
            //    Response.Redirect("Ingreso.aspx");
            //}
        }

        private void CargarRamas()
        {
            throw new NotImplementedException();
        }

        private void CargarDivisiones()
        {

            List<DivisionDto> divisiones = division.getComboDivisiones(cmbClub.SelectedIndex +1, cmbRama.SelectedIndex +1);

            if (divisiones != null)
            {
            List<ListItem> items = divisiones.ConvertAll(d =>

            {
                return new ListItem()
                {
                    Text = d.Descripcion,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            cmbDiv.DataSource = items;
            cmbDiv.DataBind();
            }
            else
            {
                List<DivisionDto> sinDivision = new List<DivisionDto>();
                List<ListItem> items = sinDivision.ConvertAll(d =>

                {
                    return new ListItem()
                    {
                        Text = "Sin Division",
                        Value = "1",
                        Selected = false
                    };
                });

                cmbDiv.DataSource = items;
                cmbDiv.DataBind();

            }
        }

        private void CargarEquipos(int clubId)
        {
            List<EquipoDto> listaEquipos = equipos.getComboEquipos();
            List<ListItem> items = listaEquipos.ConvertAll(e =>
            {
                return new ListItem()
                {
                    Text = e.NombreEquipo,
                    Value = e.Id.ToString(),
                    Selected = false
                };
            });


            cmbEquipo.DataSource = items;
            cmbEquipo.DataBind();
        }

        private void CargarClubes()
        {

            int rolId = Int32.Parse((string)Session["rolId"]);
            int clubId = Int32.Parse((string)Session["clubId"]);

            List<ClubDto> listaClubes = clubes.getComboClubes();


            List<ListItem> items = listaClubes.ConvertAll(c =>
            {
                return new ListItem()
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString(),
                    Selected = false
                };
            });

            cmbClub.DataSource = items;
            cmbClub.DataBind();

            if (rolId == 2)
            {
                cmbClub.SelectedIndex = clubId - 1;
            }
            else
            {
                cmbClub.SelectedIndex = 0;
            }
        }

        public void CargarGrilla()
        {

            int rolId = Int32.Parse((string)Session["rolId"]);
            int clubId = Int32.Parse((string)Session["clubId"]);

            if (rolId == 2)
            {
            gvJugadores.DataSource = jugadores.getGVJugadores(clubId);
            gvJugadores.DataBind();
            }
            else
            {
                gvJugadores.DataSource = jugadores.getGVJugadores(1);
                gvJugadores.DataBind();
            }
        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void cmbClub_SelectedIndexChanged1(object sender, EventArgs e)
        {
            cmbDiv.Enabled = true;
            CargarDivisiones();

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }
    }
}