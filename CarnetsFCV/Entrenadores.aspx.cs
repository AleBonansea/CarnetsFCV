using ClosedXML.Excel;
using Entidades.Dto;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Entrenadores : System.Web.UI.Page
    {
        Logica.EntrenadorLOG entrenador = new Logica.EntrenadorLOG();
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
            gvEntrenadores.DataSource = entrenador.getTotalEntrenadores();
            gvEntrenadores.DataBind();
        }


        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                gvEntrenadores.DataSource = entrenador.getBuscadorEntrenadores(txtBuscar.Text);
                gvEntrenadores.DataBind();
            }
            else
            {
                CargarGrilla();
            }
        }

        protected void modalGuardar_Click(object sender, EventArgs e)
        {
            var usuarioEntrenador = new Entidades.Usuarios();
            try
            {
                int tamanioFoto = archivo.PostedFile.ContentLength;
                byte[] imagen = new byte[tamanioFoto];
                archivo.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                int rolEntrenadorId = (int)RolesEnum.Entrenador;


                var usuarioExistente = usuario.validarUsuario(rolEntrenadorId, txtDNI.Text);

                if (usuarioExistente is null)
                {
                    

                    usuarioEntrenador.RolId = rolEntrenadorId;
                    usuarioEntrenador.NombreUsuario = txtDNI.Text;
                    usuarioEntrenador.Contraseña = txtDNI.Text;
                    usuarioEntrenador.PrimerIngreso = true;

                    usuario.crearUsuario(usuarioEntrenador);

                    var nuevoEntrenador = new Entidades.Entrenadores();

                    nuevoEntrenador.UsuarioId = usuarioEntrenador.Id;
                    nuevoEntrenador.Nombre = txtNombre.Text;
                    nuevoEntrenador.Apellido = txtApellido.Text;
                    nuevoEntrenador.FechaNac = DateTime.Parse(txtFecNac.Text);
                    nuevoEntrenador.FechaEMMAC = DateTime.Parse(txtFecEMMAC.Text);
                    nuevoEntrenador.DNI = txtDNI.Text;
                    nuevoEntrenador.Email = txtEmail.Text;
                    nuevoEntrenador.Telefono = txtTel.Text;

                    if (tamanioFoto != 0)
                    {
                        nuevoEntrenador.Foto = imagen;
                    }
                    else
                    {
                        nuevoEntrenador.Foto = null;
                    }

                    if (rdbSi.Checked)
                    {
                        nuevoEntrenador.Habilitado = true;
                    }
                    else
                    {
                        nuevoEntrenador.Habilitado = false;
                    }

                    entrenador.guardarEntrenador(nuevoEntrenador);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El entrenador se ha registrado correctamente','','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El entrenador ya existe','','info')", true);
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
                btnAgregar.Disabled = true;


            }
            catch (Exception)
            {
                usuario.EliminarUsuario(usuarioEntrenador.Id);

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El entrenador no se ha registrado correctamente','error')", true);                
            }

        }

        protected void modalModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idEntrenadorSeleccionado"] != null)
                {
                    int idEntrenador = Int32.Parse((string)Session["idEntrenadorSeleccionado"]);

                    Entidades.Entrenadores entrenadorAModificar = entrenador.getEntrenador(idEntrenador);

                    int tamanioFoto = archivoModificar.PostedFile.ContentLength;
                    byte[] imagen = new byte[tamanioFoto];
                    archivoModificar.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                    entrenadorAModificar.Nombre = txtModificarNombre.Text;
                    entrenadorAModificar.Apellido = txtModificarApellido.Text;
                    entrenadorAModificar.FechaNac = DateTime.Parse(txtModificarFecNac.Text);
                    entrenadorAModificar.FechaEMMAC = DateTime.Parse(txtModificarFecEMMAC.Text);
                    entrenadorAModificar.DNI = txtModificarDNI.Text;
                    entrenadorAModificar.Email = txtModificarEmail.Text;
                    entrenadorAModificar.Telefono = txtModificarTel.Text;
                    if (rdbModificarSi.Checked)
                    {
                        entrenadorAModificar.Habilitado = true;
                    }
                    else
                    {
                        entrenadorAModificar.Habilitado = false;
                    }

                    if (tamanioFoto != 0)
                    {
                        entrenadorAModificar.Foto = imagen;
                    }
                    else
                    {
                        entrenadorAModificar.Foto = null;
                    }


                    entrenador.modificarEntrenador(entrenadorAModificar);

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
                    "swal('El entrenador se ha modificado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El entrenador no se ha modificado','error')", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
           
            if (Session["idEntrenadorSeleccionado"] != null)
            {
                int idEntrenador = Int32.Parse((string)Session["idEntrenadorSeleccionado"]);

                var entrenadorAEliminar = entrenador.getEntrenador(idEntrenador);

                entrenador.eliminarEntrenador(idEntrenador);

                usuario.EliminarUsuario(entrenadorAEliminar.UsuarioId);

                CargarGrilla();


                Session["ultimaFilaSeleccionada"] = null;

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El entrenador se ha eliminado correctamente','','success')", true);
            }
                           
            ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                "swal('Error','El entrenador no se pudo eliminar.  Compruebe haber seleccionado uno.','error')", true);
            
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int idFilaSeleccionada = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            if (Session["ultimaFilaSeleccionada"] != null)
            {
                int ultimaFilaSeleccionada = Int32.Parse((string)Session["ultimaFilaSeleccionada"]);

                if (idFilaSeleccionada != ultimaFilaSeleccionada)
                {
                    ((CheckBox)gvEntrenadores.Rows[ultimaFilaSeleccionada].Cells[0].FindControl("chk")).Checked = false;
                }
            }


            int idEntrenador = Int32.Parse(gvEntrenadores.Rows[idFilaSeleccionada].Cells[1].Text);

            Entidades.Entrenadores entrenadorAModificar = entrenador.getEntrenador(idEntrenador);


            txtModificarNombre.Text = entrenadorAModificar.Nombre;
            txtModificarApellido.Text = entrenadorAModificar.Apellido;
            txtModificarFecNac.Text = entrenadorAModificar.FechaNac.ToString("yyyy-MM-dd");
            txtModificarFecEMMAC.Text = entrenadorAModificar.FechaEMMAC.ToString("yyyy-MM-dd");
            txtModificarDNI.Text = entrenadorAModificar.DNI;
            txtModificarEmail.Text = entrenadorAModificar.Email;
            txtModificarTel.Text = entrenadorAModificar.Telefono.ToString();

            if (entrenadorAModificar.Habilitado)
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
            Session["idEntrenadorSeleccionado"] = idEntrenador.ToString();
        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    List<EntrenadorDto> listaEntrenadores = entrenador.cargarExcel().ToList();

                    var worksheet = workbook.Worksheets.Add("Entrenadores");
                    worksheet.Cell("A1").InsertTable(listaEntrenadores);
                    worksheet.Columns(1, 8).AdjustToContents();
                    worksheet.Columns(1, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cells("A1:H1").Style.Fill.BackgroundColor = XLColor.FromArgb(228, 79, 31);
                    workbook.SaveAs(@"C:\FCV\Entrenadores.xlsx");
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
                    "swal('Se han encontrado datos para el DNI seleccionado y se han cargado. Ingrese nuevamente al formulario Agregar.','','success')", true);

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

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtFecNac.Text = "";
                txtFecEMMAC.Text = "";
                txtDNI.Text = txtValidarDni.Text;
                txtEmail.Text = "";
                txtTel.Text = "";

                btnAgregar.Disabled = false;

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El DNI ingresado no existe. Ingrese nuevamente al formulario para Agregar.','','info')", true);
            }
        }

        protected void gvEntrenadores_RowDataBound(object sender, GridViewRowEventArgs e)
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