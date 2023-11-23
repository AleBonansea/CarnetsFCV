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
    public partial class Clubes : System.Web.UI.Page
    {
        Logica.ClubLOG club = new Logica.ClubLOG();
        Logica.DelegadoLOG delegado = new Logica.DelegadoLOG();
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
            gvClubes.DataSource = club.getTotalClubes();
            gvClubes.DataBind();
        }
                

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                gvClubes.DataSource = club.getBuscadorClubes(txtBuscar.Text);
                gvClubes.DataBind();
            }
            else
            {
                CargarGrilla();
            }
        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                using (var workbook = new XLWorkbook())
                {                    
                    List<ClubDto> listaClubes = club.getTotalClubes(); ;

                    var worksheet = workbook.Worksheets.Add("Clubes");
                    worksheet.Cell("A1").InsertTable(listaClubes);
                    worksheet.Cells("A1:F1").Style.Fill.BackgroundColor = XLColor.FromArgb(228, 79, 31);
                    worksheet.Columns(1, 6).AdjustToContents();
                    worksheet.Columns(1, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    workbook.SaveAs(@"C:\FCV\Clubes.xlsx");
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

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int idFilaSeleccionada = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            if (Session["ultimaFilaSeleccionada"] != null)
            {
                int ultimaFilaSeleccionada = Int32.Parse((string)Session["ultimaFilaSeleccionada"]);

                if (idFilaSeleccionada != ultimaFilaSeleccionada)
                {
                    ((CheckBox)gvClubes.Rows[ultimaFilaSeleccionada].Cells[0].FindControl("chk")).Checked = false;
                }
            }


            int idClub = Int32.Parse(gvClubes.Rows[idFilaSeleccionada].Cells[1].Text);

            Entidades.Clubes clubAModificar = club.getClub(idClub);
            Entidades.Delegados delegadoAModificar = delegado.getDelegado(idClub);


            txtMofidicarNombreClub.Text = clubAModificar.Nombre;
            txtModificarDomicilio.Text = clubAModificar.Domicilio;

            txtModificarNombreDel.Text = delegadoAModificar.Nombre;
            txtModificarApellido.Text = delegadoAModificar.Apellido;
            txtModificarEmail.Text = delegadoAModificar.Email;
            txtModificarTel.Text = delegadoAModificar.Telefono.ToString();


            Session["ultimaFilaSeleccionada"] = idFilaSeleccionada.ToString();
            Session["idClubSeleccionado"] = idClub.ToString();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idClubSeleccionado"] != null)
                {
                    int idClub = Int32.Parse((string)Session["idClubSeleccionado"]);

                    club.eliminarClub(idClub);
                    CargarGrilla();


                    Session["ultimaFilaSeleccionada"] = null;
                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El club se ha eliminado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El club no se pudo eliminar. Compruebe haber seleccionado uno.','error')", true);
            }
        }

        protected void modalGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int rolDelegadoId = (int)RolesEnum.Delegado;


                var usuarioExistente = usuario.validarUsuario(rolDelegadoId, txtNombreClub.Text);

                if (usuarioExistente is null)
                {
                    var usuarioDelegado = new Entidades.Usuarios();

                    usuarioDelegado.RolId = rolDelegadoId;
                    usuarioDelegado.NombreUsuario = txtNombreClub.Text;
                    usuarioDelegado.Contraseña = "123";
                    usuarioDelegado.PrimerIngreso = true;

                    usuario.crearUsuario(usuarioDelegado);

                    var clubExistente = club.getClubPorNombre(txtNombreClub.Text);

                    if (clubExistente is null)
                    {
                        var nuevoClub = new Entidades.Clubes();

                        nuevoClub.Nombre = txtNombreClub.Text;
                        nuevoClub.Domicilio = txtDomicilio.Text;

                        club.guardarClub(nuevoClub);

                        var nuevoDelegado = new Entidades.Delegados();

                        nuevoDelegado.UsuarioId = usuarioDelegado.Id;
                        nuevoDelegado.ClubId = nuevoClub.Id;
                        nuevoDelegado.Nombre = txtNombreDelegado.Text;
                        nuevoDelegado.Apellido = txtApellido.Text;
                        nuevoDelegado.Email = txtEmail.Text;
                        nuevoDelegado.Telefono = txtTel.Text;

                        delegado.guardarDelegado(nuevoDelegado);

                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('El club se ha registrado correctamente','','success')", true);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('El club ya existe','','info')", true);
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El delegado ya existe','','info')", true);
                }

                CargarGrilla();

                txtNombreClub.Text = "";
                txtDomicilio.Text = "";
                txtNombreDelegado.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtTel.Text = "";

            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                                    "swal('Error','El club no se ha registrado correctamente','error')", true);
            }
        }

        protected void modalModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idClubSeleccionado"] != null)
                {
                    int idClub = Int32.Parse((string)Session["idClubSeleccionado"]);

                    Entidades.Clubes clubAModificar = club.getClub(idClub);


                    clubAModificar.Nombre = txtMofidicarNombreClub.Text;
                    clubAModificar.Domicilio = txtModificarDomicilio.Text;
                                       

                    club.modificarClub(clubAModificar);

                    Entidades.Delegados delegadoAModificar = delegado.getDelegado(idClub);

                    delegadoAModificar.UsuarioId = delegadoAModificar.UsuarioId;
                    delegadoAModificar.ClubId = delegadoAModificar.ClubId;
                    delegadoAModificar.Nombre = txtModificarNombreDel.Text;
                    delegadoAModificar.Apellido = txtModificarApellido.Text;
                    delegadoAModificar.Email = txtModificarEmail.Text;
                    delegadoAModificar.Telefono = txtModificarTel.Text;

                    delegado.modificarDelegado(delegadoAModificar);


                    CargarGrilla();

                    txtNombreClub.Text = "";
                    txtDomicilio.Text = "";
                    txtNombreDelegado.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtTel.Text = "";
                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El club se ha modificado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El club no se ha modificado','error')", true);
            }
        }
    }
}