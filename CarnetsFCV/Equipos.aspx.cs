using ClosedXML.Excel;
using Entidades;
using Entidades.Dto;
using Entidades.Enums;
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
        Logica.EquipoLOG equipo = new Logica.EquipoLOG();
        Logica.DivisionLOG division = new Logica.DivisionLOG();
        Logica.RamaLOG rama = new Logica.RamaLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                CargarDivisiones();
                CargarRamas();
                txtModificarNombre.Enabled = false;
                cmbModificarDivision.Enabled = false;
                cmbModificarRama.Enabled = false;

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
            gvEquipos.DataSource = equipo.getTotalEquipos(clubId);
            gvEquipos.DataBind();
        }


        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            int clubId = Int32.Parse((string)Session["clubId"]);
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                gvEquipos.DataSource = equipo.getBuscadorEquipos(txtBuscar.Text, clubId);
                gvEquipos.DataBind();
            }
            else
            {
                CargarGrilla(clubId);
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

                cmbModificarRama.DataSource = ramas;
                cmbModificarRama.DataTextField = "Descripcion";
                cmbModificarRama.DataValueField = "Id";
                cmbModificarRama.DataBind();
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

                cmbRama.DataSource = items;
                cmbRama.DataBind();

                cmbModificarRama.DataSource = items;
                cmbModificarRama.DataBind();

            }
        }

        private void CargarDivisiones()
        {
            List<DivisionDto> divisiones = division.getDivisiones();
            
            if (divisiones != null)
            {
                cmbDivisiones.DataSource = divisiones;
                cmbDivisiones.DataTextField = "Descripcion";
                cmbDivisiones.DataValueField = "Id";
                cmbDivisiones.DataBind();

                cmbModificarDivision.DataSource = divisiones;
                cmbModificarDivision.DataTextField = "Descripcion";
                cmbModificarDivision.DataValueField = "Id";
                cmbModificarDivision.DataBind();
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

                cmbDivisiones.DataSource = items;
                cmbDivisiones.DataBind();

                cmbModificarDivision.DataSource = items;
                cmbModificarDivision.DataBind();

            }
        }

        protected void modalGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoEquipo = new Entidades.Equipos();

                nuevoEquipo.ClubId = Int32.Parse((string)Session["clubId"]);
                nuevoEquipo.DivisionId = cmbDivisiones.SelectedIndex + 1;
                nuevoEquipo.RamaId = cmbRama.SelectedIndex + 1;
                nuevoEquipo.Nombre = txtNombre.Text;

                equipo.guardarEquipo(nuevoEquipo);

                CargarGrilla(nuevoEquipo.ClubId);

                txtNombre.Text = "";

                ClientScript.RegisterClientScriptBlock(this.GetType(),"k",
                    "swal('El equipo se ha registrado correctamente','','success')",true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El equipo no ha registrado correctamente','error')", true);
            }
            
        }

        protected void cmbDivisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDivisiones.SelectedIndex = cmbDivisiones.SelectedIndex + 1;

        }
        protected void cmbRama_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRama.SelectedIndex = cmbRama.SelectedIndex;
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            txtModificarNombre.Enabled = true;
            cmbModificarDivision.Enabled = true;
            cmbModificarRama.Enabled = true;

            int idFilaSeleccionada = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            
            
            if (Session["ultimaFilaSeleccionada"] != null)
            {
                int ultimaFilaSeleccionada = Int32.Parse((string)Session["ultimaFilaSeleccionada"]);
                
                if (idFilaSeleccionada != ultimaFilaSeleccionada)
                {
                    ((CheckBox)gvEquipos.Rows[ultimaFilaSeleccionada].Cells[0].FindControl("chk")).Checked = false;
                }
            }


            int idEquipo = Int32.Parse(gvEquipos.Rows[idFilaSeleccionada].Cells[1].Text);

            Entidades.Equipos equipoAModificar = equipo.getEquipo(idEquipo);

            txtModificarNombre.Text = equipoAModificar.Nombre;
            cmbModificarDivision.SelectedIndex = equipoAModificar.DivisionId - 1;
            cmbModificarRama.SelectedIndex = equipoAModificar.RamaId - 1;

            Session["ultimaFilaSeleccionada"] = idFilaSeleccionada.ToString();
            Session["idEquipoSeleccionado"] = idEquipo.ToString();

        }

        protected void modalModificar_Click(object sender, EventArgs e)
        {

            
            try
            {
                if (Session["idEquipoSeleccionado"] != null)
                {
                    int idEquipo = Int32.Parse((string)Session["idEquipoSeleccionado"]);

                    Entidades.Equipos equipoAModificar = equipo.getEquipo(idEquipo);

                    equipoAModificar.DivisionId = cmbModificarDivision.SelectedIndex + 1;
                    equipoAModificar.RamaId = cmbModificarRama.SelectedIndex + 1;
                    equipoAModificar.Nombre = txtModificarNombre.Text;


                    equipo.modificarEquipo(equipoAModificar);
                    CargarGrilla(equipoAModificar.ClubId);
                    txtModificarNombre.Text = "";

                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El equipo se ha modificado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El equipo no se ha modificado','error')", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int clubId = Int32.Parse((string)Session["clubId"]);
                if (Session["idEquipoSeleccionado"] != null)
                {
                    int idEquipo = Int32.Parse((string)Session["idEquipoSeleccionado"]);

                    equipo.eliminarEquipo(idEquipo);
                    CargarGrilla(clubId);


                    Session["ultimaFilaSeleccionada"] = null;
                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El equipo se ha eliminado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El equipo no se pudo eliminar','error')", true);
            }
        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    int clubId = Int32.Parse((string)Session["clubId"]);

                    List<EquipoDto> listaEquipos = equipo.getTotalEquipos(clubId);

                    var worksheet = workbook.Worksheets.Add("Entrenadores");
                    worksheet.Cell("A1").InsertTable(listaEquipos);
                    worksheet.Cells("A1:F1").Style.Fill.BackgroundColor = XLColor.FromArgb(228, 79, 31);
                    worksheet.Columns(1, 5).AdjustToContents();
                    worksheet.Columns(1, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    workbook.SaveAs(@"C:\FCV\Equipos.xlsx");
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El excel se ha descargado correctamente','','success')", true);
            }

            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El excel no pudo ser descargado','error')", true);
            }
        }
    }
}