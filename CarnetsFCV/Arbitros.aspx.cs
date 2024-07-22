using ClosedXML.Excel;
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
    public partial class Arbitros : System.Web.UI.Page
    {
        Logica.ArbitroLOG arbitro = new Logica.ArbitroLOG();
        Logica.UsuarioLOG usuario = new Logica.UsuarioLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["rolId"] != null)
                {
                    CargarGrilla();
                    txtDNI.Enabled = false;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtFecNac.Enabled = false;
                    txtFecEMMAC.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTel.Enabled = false;
                    btnAgregar.Disabled = true;
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

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }

        public void CargarGrilla()
        {
            gvArbitros.DataSource = arbitro.getTotalArbitros();
            gvArbitros.DataBind();
        }


        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                gvArbitros.DataSource = arbitro.getBuscadorArbitros(txtBuscar.Text);
                gvArbitros.DataBind();
            }
            else
            {
                CargarGrilla();
            }
        }

        protected void modalGuardar_Click(object sender, EventArgs e)
        {
            var usuarioArbitro = new Entidades.Usuarios();

            try
            {
                int tamanioFoto = archivo.PostedFile.ContentLength;
                byte[] imagen = new byte[tamanioFoto];
                archivo.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                int rolArbitroId = (int)RolesEnum.Arbitro;


                var usuarioExistente = usuario.validarUsuario(rolArbitroId, txtDNI.Text);

                if (usuarioExistente is null)
                {

                    usuarioArbitro.RolId = rolArbitroId;
                    usuarioArbitro.NombreUsuario = txtDNI.Text;
                    usuarioArbitro.Contraseña = txtDNI.Text;
                    usuarioArbitro.PrimerIngreso = true;

                    usuario.crearUsuario(usuarioArbitro);

                    var nuevoArbitro = new Entidades.Arbitros();

                    nuevoArbitro.UsuarioId = usuarioArbitro.Id;
                    nuevoArbitro.Nombre = txtNombre.Text;
                    nuevoArbitro.Apellido = txtApellido.Text;
                    nuevoArbitro.FechaNac = DateTime.Parse(txtFecNac.Text);
                    nuevoArbitro.FechaEMMAC = DateTime.Parse(txtFecEMMAC.Text);
                    nuevoArbitro.DNI = txtDNI.Text;
                    nuevoArbitro.Email = txtEmail.Text;
                    nuevoArbitro.Telefono = txtTel.Text;

                    if (tamanioFoto != 0)
                    {
                        nuevoArbitro.Foto = imagen;
                    }
                    else
                    {
                        nuevoArbitro.Foto = null;
                    }

                    if (rdbSi.Checked)
                    {
                        nuevoArbitro.Habilitado = true;
                    }
                    else
                    {
                        nuevoArbitro.Habilitado = false;
                    }

                    arbitro.guardarArbitro(nuevoArbitro);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El árbitro se ha registrado correctamente','','success')", true);
                }
                else
                {
                    usuario.EliminarUsuario(usuarioArbitro.Id);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El áritro ya existe','','info')", true);
                }
                CargarGrilla();

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtFecNac.Text = "";
                txtFecEMMAC.Text = "";
                txtDNI.Text = "";
                txtEmail.Text = "";
                txtTel.Text = "";
                rdbNo.Checked = false;
                rdbSi.Checked = true;


            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El árbitro no se ha registrado correctamente','error')", true);
            }

        }

        protected void modalModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idArbitroSeleccionado"] != null)
                {
                    int idArbitro = Int32.Parse((string)Session["idArbitroSeleccionado"]);

                    Entidades.Arbitros arbitroAModificar = arbitro.getArbitro(idArbitro);

                    int tamanioFoto = archivoModificar.PostedFile.ContentLength;
                    byte[] imagen = new byte[tamanioFoto];
                    archivoModificar.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                    arbitroAModificar.Nombre = txtModificarNombre.Text;
                    arbitroAModificar.Apellido = txtModificarApellido.Text;
                    arbitroAModificar.FechaNac = DateTime.Parse(txtModificarFecNac.Text);
                    arbitroAModificar.FechaEMMAC = DateTime.Parse(txtModificarFecEMMAC.Text);
                    arbitroAModificar.DNI = txtModificarDNI.Text;
                    arbitroAModificar.Email = txtModificarEmail.Text;
                    arbitroAModificar.Telefono = txtModificarTel.Text;
                    if (rdbModificarSi.Checked)
                    {
                        arbitroAModificar.Habilitado = true;
                    }
                    else
                    {
                        arbitroAModificar.Habilitado = false;
                    }

                    byte[] sinImagen = new byte[0];

                    if (tamanioFoto != 0)
                    {
                        arbitroAModificar.Foto = imagen;
                    }
                    else
                    {
                        arbitroAModificar.Foto = null;
                    }


                    arbitro.modificarArbitro(arbitroAModificar);

                    CargarGrilla();

                    txtModificarNombre.Text = "";
                    txtModificarNombre.Text = "";
                    txtModificarApellido.Text = "";
                    txtModificarFecNac.Text = "";
                    txtModificarFecEMMAC.Text = "";
                    txtModificarDNI.Text = "";
                    txtModificarEmail.Text = "";
                    txtModificarTel.Text = "";
                    rdbModificarSi.Checked = false;
                    rdbModificarNo.Checked = false;
                    archivoModificar = null;

                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El árbitro se ha modificado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El árbitro no se ha modificado','error')", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
           
            if (Session["idArbitroSeleccionado"] != null)
            {
                int idArbitro = Int32.Parse((string)Session["idArbitroSeleccionado"]);

                var arbitroAEliminar = arbitro.getArbitro(idArbitro);

                arbitro.eliminarArbitro(idArbitro);

                usuario.EliminarUsuario(arbitroAEliminar.UsuarioId);

                CargarGrilla();


                Session["ultimaFilaSeleccionada"] = null;

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El árbitro se ha eliminado correctamente','','success')", true);
            }

            
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El árbitro no se pudo eliminar','error')", true);
            
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int idFilaSeleccionada = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            if (Session["ultimaFilaSeleccionada"] != null)
            {
                int ultimaFilaSeleccionada = Int32.Parse((string)Session["ultimaFilaSeleccionada"]);

                if (idFilaSeleccionada != ultimaFilaSeleccionada)
                {
                    ((CheckBox)gvArbitros.Rows[ultimaFilaSeleccionada].Cells[0].FindControl("chk")).Checked = false;
                }
            }


            int idArbitro = Int32.Parse(gvArbitros.Rows[idFilaSeleccionada].Cells[1].Text);

            Entidades.Arbitros arbitroAModificar = arbitro.getArbitro(idArbitro);


            txtModificarNombre.Text = arbitroAModificar.Nombre;
            txtModificarApellido.Text = arbitroAModificar.Apellido;
            txtModificarFecNac.Text = arbitroAModificar.FechaNac.ToString("yyyy-MM-dd");
            txtModificarFecEMMAC.Text = arbitroAModificar.FechaEMMAC.ToString("yyyy-MM-dd");
            txtModificarDNI.Text = arbitroAModificar.DNI;
            txtModificarEmail.Text = arbitroAModificar.Email;
            txtModificarTel.Text = arbitroAModificar.Telefono.ToString();

            if (arbitroAModificar.Habilitado)
            {
                rdbModificarSi.Checked = true;
                rdbModificarNo.Checked = false;
            }
            else
            {
                rdbModificarSi.Checked = false;
                rdbModificarNo.Checked = true;
            }

            Session["ultimaFilaSeleccionada"] = idFilaSeleccionada.ToString();
            Session["idArbitroSeleccionado"] = idArbitro.ToString();
        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    List<ArbitroDto> listaEntrenadores = arbitro.cargarExcel().ToList();

                    var worksheet = workbook.Worksheets.Add("Arbitros");
                    worksheet.Cell("A1").InsertTable(listaEntrenadores);
                    worksheet.Columns(1, 8).AdjustToContents();
                    worksheet.Columns(1, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cells("A1:H1").Style.Fill.BackgroundColor = XLColor.FromArgb(228, 79, 31);
                    workbook.SaveAs(@"C:\FCV\Arbitros.xlsx");
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

        protected void btnValidarDNI_Click(object sender, EventArgs e)
        {
            int tamanioFoto = archivo.PostedFile.ContentLength;
            byte[] imagen = new byte[tamanioFoto];
            archivo.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

            var user = usuario.getUsuarioByNombre(txtValidarDni.Text);

            if (user != null)
            {
                txtNombre.Text = user.Nombre;
                txtApellido.Text = user.Apellido;
                txtFecNac.Text = user.FechaNac.ToString("yyyy-MM-dd");
                txtFecEMMAC.Text = user.FechaEMMAC.ToString("yyyy-MM-dd");
                txtDNI.Text = user.DNI;
                txtEmail.Text = user.Email;
                txtTel.Text = user.Telefono;
                archivo.PostedFile.InputStream.Read(user.Foto, 0, tamanioFoto);

                if (user.Habilitado)
                {
                    rdbSi.Checked = true;
                    rdbNo.Checked = false;
                }
                else
                {
                    rdbSi.Checked = false;
                    rdbNo.Checked = true;
                }

                btnAgregar.Disabled = false;

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Se han encontrado datos para el DNI seleccionado y se han cargado. Ingrese al formulario Agregar.','','success')", true);

            }
            else
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtFecNac.Enabled = true;
                txtFecEMMAC.Enabled = true;
                txtDNI.Enabled = true;
                txtEmail.Enabled = true;
                txtTel.Enabled = true;
                txtDNI.Enabled = true;

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtFecNac.Text = "";
                txtFecEMMAC.Text = "";
                txtDNI.Text = txtValidarDni.Text;
                txtEmail.Text = "";
                txtTel.Text = "";

                btnAgregar.Disabled = false;

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El DNI ingresado no existe. Ingrese al formulario Agregar.','','info')", true);
            }
        }

        protected void ModalCancelar_click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFecNac.Text = "";
            txtFecEMMAC.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            rdbNo.Checked = false;
            rdbSi.Checked = true;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtFecNac.Enabled = false;
            txtFecEMMAC.Enabled = false;
            txtEmail.Enabled = false;
            txtTel.Enabled = false;
            txtDNI.Enabled = false;

            btnAgregar.Disabled = true;
        }

        protected void gvArbitros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
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
    }
}