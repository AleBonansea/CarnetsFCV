using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using Entidades;
using Entidades.Dto;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Habilitaciones : System.Web.UI.Page
    {
        Logica.JugadorLOG jugador = new Logica.JugadorLOG();
        Logica.ClubLOG clubes = new Logica.ClubLOG();
        Logica.EquipoLOG equipos = new Logica.EquipoLOG();
        Logica.DivisionLOG division = new Logica.DivisionLOG();
        Logica.UsuarioLOG usuario = new Logica.UsuarioLOG();
        Logica.RamaLOG rama = new Logica.RamaLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            int rolId = Int32.Parse((string)Session["rolId"]);

            

            if (!IsPostBack)
            {
                if (Session["rolId"] != null)
                {
                    CargarClubes();
                    CargarRamas();
                    CargarDivisiones();
                    lblEquipos.Visible = false;
                    btnSeleccionar.Visible = false;
                    cmbEquipo.Visible = false;
                }
                else
                {
                    Response.Redirect("Ingreso.aspx");
                }
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        
        private void CargarClubes()
        {
            List<ClubDto> listaClubes = clubes.getComboClubes();


            if (listaClubes != null)
            {
                cmbClub.DataSource = listaClubes;
                cmbClub.DataTextField = "Nombre";
                cmbClub.DataValueField = "Id";
                cmbClub.DataBind();
            }

        }

        private void CargarRamas()
        {
            List<Ramas> ramas = rama.getRamas();

            if (ramas != null)
            {
                cmbRama.DataSource = ramas;
                cmbRama.DataTextField = "Descripcion";
                cmbRama.DataValueField = "Id";
                cmbRama.DataBind();
            }
        }

        private void CargarDivisiones()
        {

            List<Divisiones> divisiones = division.getDivisiones();
            cmbDiv.Items.Clear();

            if (divisiones != null)
            {
                cmbDiv.DataSource = divisiones;
                cmbDiv.DataTextField = "Descripcion";
                cmbDiv.DataValueField = "Id";
                cmbDiv.DataBind();
            }
        }
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();

            foreach (GridViewRow row in gvJugadores.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chk");
                if (chkSelect != null && chkSelect.Checked)
                {
                    int id = Convert.ToInt32(gvJugadores.DataKeys[row.RowIndex].Value);
                    selectedIds.Add(id);
                }
            }

            // Habilitar o deshabilitar los botones según la cantidad de seleccionados
            bool hasSelections = selectedIds.Count > 0;
            btnHabilitar.Enabled = hasSelections;
            btnDeshabilitar.Enabled = hasSelections;

            // Guarda los IDs seleccionados en un campo oculto (si es necesario)
            filaSeleccionada.Value = string.Join(",", selectedIds);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }       

        protected void btnFiltros_Click(object sender, EventArgs e)
        {
            var clubId = Int32.Parse((String)cmbClub.SelectedValue);
            var divisionId = Int32.Parse((String)cmbDiv.SelectedValue);
            var ramaId = Int32.Parse((String)cmbRama.SelectedValue);

            List<Entidades.Equipos> listaEquipos = equipos.GetEquiposHabilitaciones(clubId, divisionId, ramaId);

            cmbEquipo.Items.Clear();

            if (listaEquipos.Any())
            {
                cmbEquipo.DataSource = listaEquipos;
                cmbEquipo.DataTextField = "Nombre";
                cmbEquipo.DataValueField = "Id";
                cmbEquipo.DataBind();
                lblEquipos.Visible = true;
                btnSeleccionar.Visible = true;
                cmbEquipo.Visible = true;
            }
            else 
            {
                lblEquipos.Visible = false;
                btnSeleccionar.Visible = false;
                cmbEquipo.Visible = false;
                gvJugadores.Visible = false;

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('No existen equipos para el filtro seleccionado.','','info')", true);
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var equipoId = Int32.Parse((String)cmbEquipo.SelectedValue);
            List<Entidades.Dto.JugadorDto> jugadoresEquipo = jugador.GetJugadoresEquipo(equipoId);

            if (jugadoresEquipo != null)
            {
                gvJugadores.Visible = true;
                gvJugadores.DataSource = jugadoresEquipo;
                gvJugadores.DataBind();
            }
        }

        protected void gvJugadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                // Encuentra el control de imagen
                Image imgHabilitado = (Image)e.Row.FindControl("imgHabilitado");

                // Obtén el valor del campo Habilitado
                bool habilitado = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Habilitado"));

                // Asigna la imagen correspondiente según el valor del campo Habilitado
                if (habilitado)
                {
                    imgHabilitado.ImageUrl = "~/Imagenes/habilitado.png"; // Ruta a la imagen para habilitado
                    imgHabilitado.AlternateText = "Habilitado";
                }
                else
                {
                    imgHabilitado.ImageUrl = "~/Imagenes/no_habilitado.png"; // Ruta a la imagen para no habilitado
                    imgHabilitado.AlternateText = "No habilitado";
                }
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            var ids = filaSeleccionada.Value.Split(',');
            List<int> selectedIds = new List<int>();
            foreach (var id in ids)
            {
                selectedIds.Add(int.Parse(id));
            }

            using (var context = new Entidades.Modelo())
            {
                var jugadores = context.Jugadores.Where(j => selectedIds.Contains(j.Id)).ToList();
                foreach (var jugador in jugadores)
                {
                    jugador.Habilitado = true;
                }
                context.SaveChanges();
            }

            // Recargar la grilla después de actualizar
            CargarJugadores();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            var ids = filaSeleccionada.Value.Split(',');
            List<int> selectedIds = new List<int>();
            foreach (var id in ids)
            {
                selectedIds.Add(int.Parse(id));
            }

            using (var context = new Entidades.Modelo())
            {
                var jugadores = context.Jugadores.Where(j => selectedIds.Contains(j.Id)).ToList();
                foreach (var jugador in jugadores)
                {
                    jugador.Habilitado = false;
                }
                context.SaveChanges();
            }

            // Recargar la grilla después de actualizar
            CargarJugadores();
        }
        private void CargarJugadores()
        {
            var equipoId = Int32.Parse((String)cmbEquipo.SelectedValue);
            List<Entidades.Dto.JugadorDto> jugadoresEquipo = jugador.GetJugadoresEquipo(equipoId);

            if (jugadoresEquipo != null)
            {
                gvJugadores.Visible = true;
                gvJugadores.DataSource = jugadoresEquipo;
                gvJugadores.DataBind();
            }
        }
    }
}