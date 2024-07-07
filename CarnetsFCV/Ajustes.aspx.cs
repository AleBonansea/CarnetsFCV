using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Ajustes : System.Web.UI.Page
    {
        Logica.SexoLOG sexo = new Logica.SexoLOG();
        Logica.DivisionLOG division = new Logica.DivisionLOG();
        Logica.RamaLOG rama = new Logica.RamaLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            int rolId = Int32.Parse((string)Session["rolId"]);


            if (!IsPostBack)
            {
                if (Session["rolId"] != null)
                {
                    Session["IdSeleccionado"] = null;
                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;

                    // Código para ejecutar solo la primera vez que se carga la página
                    cmbAjustes.Items.Insert(0, new ListItem("Seleccionar", ""));
                    cmbAjustes.SelectedIndex = 0;
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

        protected void cmbAjustes_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListItem seleccionarItem = cmbAjustes.Items.FindByText("Seleccionar");
                if (seleccionarItem != null)
            {
                cmbAjustes.Items.Remove(seleccionarItem);
            }

            string selectedValue = cmbAjustes.SelectedValue;

            Session["EntidadSeleccionada"] = selectedValue;

            cargarGrilla();
        }

        private void cargarGrilla()
        {
            IEnumerable<dynamic> datos = null;

            string entidadSeleccionada = Session["EntidadSeleccionada"] as string;

            if (entidadSeleccionada != null)
            {
                switch (entidadSeleccionada)
                {
                    case "Divisiones":
                        datos = division.getDivisiones();
                        break;
                    case "Ramas":
                        datos = rama.getRamas();
                        break;
                    case "Sexos":
                        datos = sexo.getSexos();
                        break;
                }
            }
            
            gvAjustes.DataSource = datos;
            gvAjustes.DataBind();

            btnGuardar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int idFilaSeleccionada = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            int idSeleccionado = Int32.Parse(gvAjustes.Rows[idFilaSeleccionada].Cells[1].Text);



            if (Session["ultimaFilaSeleccionada"] != null)
            {
                int ultimaFilaSeleccionada = Int32.Parse((string)Session["ultimaFilaSeleccionada"]);

                if (idFilaSeleccionada != ultimaFilaSeleccionada)
                {
                    ((CheckBox)gvAjustes.Rows[ultimaFilaSeleccionada].Cells[0].FindControl("chk")).Checked = false;
                }
            }

            string entidadSeleccionada = Session["EntidadSeleccionada"] as string;

            if (entidadSeleccionada != null)
            {
                switch (entidadSeleccionada)
                {
                    case "Divisiones":
                        var divisionAModificar = division.getDivision(idSeleccionado);

                        txtModificarDescripcion.Text = divisionAModificar.Descripcion;

                        break;
                    case "Ramas":
                        var ramaAModificar = rama.getRama(idSeleccionado);

                        txtModificarDescripcion.Text = ramaAModificar.Descripcion;

                        break;
                    case "Sexos":
                        var sexoAModificar = sexo.getSexo(idSeleccionado);

                        txtModificarDescripcion.Text = sexoAModificar.Descripcion;

                        break;
                }
            }

            Session["IdSeleccionado"] = idSeleccionado.ToString();

            Session["ultimaFilaSeleccionada"] = idFilaSeleccionada.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string entidadSeleccionada = Session["EntidadSeleccionada"] as string;

                if (entidadSeleccionada != null)
                {
                    switch (entidadSeleccionada)
                    {
                        case "Divisiones":
                            Divisiones divisionNueva = new Divisiones()
                            {
                                Descripcion = txtDescripcion.Text
                            };

                            division.GuardarDivision(divisionNueva);

                            break;

                        case "Ramas":
                            Ramas ramaNueva = new Ramas()
                            {
                                Descripcion = txtDescripcion.Text
                            };

                            rama.GuardarRama(ramaNueva);

                            break;

                        case "Sexos":
                            Sexos sexoNuevo = new Sexos()
                            {
                                Descripcion = txtDescripcion.Text
                            };

                            sexo.GuardarSexo(sexoNuevo);

                            break;
                    }

                    cargarGrilla();
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('El ajuste se ha registrado correctamente','','success')", true);
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El ajuste no ha registrado correctamente','error')", true);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string entidadSeleccionada = Session["EntidadSeleccionada"] as string;

                int id = Int32.Parse((string)Session["IdSeleccionado"]);

                if (entidadSeleccionada != null)
                {
                    switch (entidadSeleccionada)
                    {
                        case "Divisiones":

                            var divisionAModificar = division.getDivision(id);

                            divisionAModificar.Descripcion = txtModificarDescripcion.Text;

                            division.ActualizarDivision(divisionAModificar);

                            cargarGrilla();

                            break;

                        case "Ramas":

                            var ramasAModificar = rama.getRama(id);

                            ramasAModificar.Descripcion = txtModificarDescripcion.Text;

                            rama.ActualizarRama(ramasAModificar);

                            cargarGrilla();

                            break;

                        case "Sexos":

                            var sexoAModificar = sexo.getSexo(id);

                            sexoAModificar.Descripcion = txtModificarDescripcion.Text;

                            sexo.ActualizarSexo(sexoAModificar);

                            cargarGrilla();

                            break;
                    }
                    Session["ultimaFilaSeleccionada"] = null;

                    cargarGrilla();

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('El ajuste se ha modificado correctamente','','success')", true);
                }
            }
            catch 
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El ajuste no se pudo modificar.  Compruebe haber seleccionado uno o que no esté en uso.','error')", true);
            }
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string entidadSeleccionada = Session["EntidadSeleccionada"] as string;

                int id = Int32.Parse((string)Session["IdSeleccionado"]);

                if (Session["IdSeleccionado"] != null)
                {
                    if (entidadSeleccionada != null)
                    {
                        switch (entidadSeleccionada)
                        {
                            case "Divisiones":

                                division.EliminarDivision(id);

                                break;

                            case "Ramas":
                                rama.EliminarRama(id);

                                break;

                            case "Sexos":
                                sexo.EliminarSexo(id);

                                break;
                        }

                        Session["ultimaFilaSeleccionada"] = null;

                        cargarGrilla();

                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                            "swal('El ajuste se ha eliminado correctamente','','success')", true);
                    }
                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El ajuste no se pudo eliminar.  Compruebe haber seleccionado uno o que no esté en uso.','error')", true);
            }
        }
    }
}