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
            try
            {
                int tamanioFoto = archivo.PostedFile.ContentLength;
                byte[] imagen = new byte[tamanioFoto];
                archivo.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                int rolArbitroId = (int)RolesEnum.Arbitro;


                var usuarioExistente = usuario.validarUsuario(rolArbitroId, txtDNI.Text);

                if (usuarioExistente is null)
                {
                    var usuarioArbitro = new Entidades.Usuarios();

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
                    nuevoArbitro.Foto = imagen;
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

                    if (imagen != sinImagen)
                    {
                        arbitroAModificar.Foto = imagen;
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
            try
            {
                if (Session["idArbitroSeleccionado"] != null)
                {
                    int idEntrenador = Int32.Parse((string)Session["idArbitroSeleccionado"]);

                    arbitro.eliminarArbitro(idEntrenador);
                    CargarGrilla();


                    Session["ultimaFilaSeleccionada"] = null;
                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El árbitro se ha eliminado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El árbitro no se pudo eliminar','error')", true);
            }
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
    }
}